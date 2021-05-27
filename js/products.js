const getProducts = async () => {
    try {
      const results = await fetch("./data/products.json");
      const data = await results.json();
      const products = data.products;
      return products;
    } catch (err) {
      console.log(err);
    }
  };
//   Load Category Products

const categoryCenter = document.querySelector(".category__center");
  
window.addEventListener("DOMContentLoaded", async function () {
    const products = await getProducts();
    displayProductItems(products);
});

const displayProductItems = items => {
    let displayProduct = items.map(
      product => ` 
                    <div class="product category__products">
                      <div class="product__header">
                        <img src=${product.image} alt="product">
                      </div>
                      <div class="product__footer">
                        <h3>${product.title}</h3>
                        <div class="rating">
                          <svg>
                            <use xlink:href="./images/sprite.svg#icon-star-full"></use>
                          </svg>
                          <svg>
                            <use xlink:href="./images/sprite.svg#icon-star-full"></use>
                          </svg>
                          <svg>
                            <use xlink:href="./images/sprite.svg#icon-star-full"></use>
                          </svg>
                          <svg>
                            <use xlink:href="./images/sprite.svg#icon-star-full"></use>
                          </svg>
                          <svg>
                            <use xlink:href="./images/sprite.svg#icon-star-empty"></use>
                          </svg>
                        </div>
                        <div class="product__price">
                          <h4>$${product.price}</h4>
                        </div>
                        <a href="#"><button type="submit" class="product__btn">Add To Cart</button></a>
                      </div>
                    <ul>
                        <li>
                          <a data-tip="Quick View" data-place="left" href="#">
                            <svg>
                              <use xlink:href="./images/sprite.svg#icon-eye"></use>
                            </svg>
                          </a>
                        </li>
                        <li>
                          <a data-tip="Add To Wishlist" data-place="left" href="#">
                            <svg>
                              <use xlink:href="./images/sprite.svg#icon-heart-o"></use>
                            </svg>
                          </a>
                        </li>
                        <li>
                          <a data-tip="Add To Compare" data-place="left" href="#">
                            <svg>
                              <use xlink:href="./images/sprite.svg#icon-loop2"></use>
                            </svg>
                          </a>
                        </li>
                    </ul>
                    </div>
                    `
    );

    displayProduct = displayProduct.join("");
    if (categoryCenter) {
        categoryCenter.innerHTML = displayProduct;
    }
};


const filterBtn = document.querySelectorAll(".filter-btn");
const categoryContainer = document.getElementById("category");

if (categoryContainer) {
  categoryContainer.addEventListener("click", async e => {
    const target = e.target.closest(".section__title");
    if (!target) return;

    const id = target.dataset.id;
    const products = await getProducts();

    if (id) {
      // remove active from buttons
      Array.from(filterBtn).forEach(btn => {
        btn.classList.remove("active");
      });
      target.classList.add("active");

      // Load Products
      let menuCategory = products.filter(product => {
        if (product.category === id) {
          return product;
        }
      });

      if (id === "All Products") {
        displayProductItems(products);
      } else {
        displayProductItems(menuCategory);
      }
    }
  });
}