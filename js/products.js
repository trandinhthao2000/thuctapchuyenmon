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

/*
=============
Load Category Products
=============
 */
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

/*
=============
Filtering
=============
 */

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


// shopping cartNumbers
let products = [{
  id: 6,
  title: "Apple iPhone 11",
  image: "./images/products/iphone/iphone3.jpeg",
  price: 760,
  category: "Featured Products",
  inCart:0,      
},
{
  id: 3,
  title: "Sony WH-CH510",
  image: "./images/products/headphone/headphone2.jpeg",
  price: 265,
  category: "Special Products",
  inCart:0      
},
{
  id: 4,
  title: "Apple iPhone 11",
  image: "./images/products/iphone/iphone2.jpeg",
  price: 850,
  category: "Special Products",
  inCart:0,      
},
{
  id: 8,
  title: "Apple iPhone 11",
  image: "./images/products/iphone/iphone4.jpeg",
  price: 290,
  category: "Featured Products",
  inCart:0,
},
{
  id: 5,
  title: "Sony WH-CH510",
  image: "./images/products/headphone/headphone3.jpeg",
  price: 250,
  category: "Special Products",
  inCart:0,      
},
{
  id: 7,
  title: "Sony WH-CH510",
  image: "./images/products/headphone/headphone4.jpeg",
  price: 365,
  category: "Featured Products",
  inCart:0,
},
{
  id: 10,
  title: "Apple iPhone 11 Pro",
  image: "./images/products/iphone/iphone5.jpeg",
  price: 385,
  category: "Special Products",
  inCart:0,      
},
{
  id: 11,
  title: "Sony WH-CH510",
  image: "./images/products/headphone/headphone6.jpeg",
  price: 475,
  category: "Special Products",
  inCart:0,      
},
{
  id: 13,
  title: "Apple iPhone 11",
  image: "./images/products/iphone/iphone6.jpeg",
  price: 800,
  category: "Trending Products",
  inCart:0,
},
{
  id: 12,
  title: "Sony WH-CH510",
  image: "./images/products/headphone/headphone7.jpeg",
  price: 850,
  category: "Special Products",
  inCart:0,      
},
{
  id: 14,
  title: "Sony WH-CH510",
  image: "./images/products/headphone/headphone7.jpeg",
  price: 360,
  category: "Trending Products",
  inCart:0,
},
{
  id: 9,
  title: "Sony WH-CH510",
  image: "./images/products/headphone/headphone5.jpeg",
  price: 320,
  category: "Special Products",
  inCart:0,      

},
{
  id: 15,
  title: "Sony WH-CH510",
  image: "./images/products/headphone/headphone8.jpeg",
  price: 305,
  category: "Trending Products",
  inCart:0,
},
{
  id: 16,
  title: "Samsung Galaxy",
  image: "./images/products/sumsung/samsung6.jpeg",
  price: 400,
  category: "Special Products",
  inCart:0,      
},
{
  id: 17,
  title: "Samsung Galaxy",
  image: "./images/products/sumsung/samsung5.jpeg",
  price: 550,
  category: "Trending Products",
  inCart:0,
},
{
  id: 2,
  title: "Apple iPhone 11",
  image: "./images/products/iphone/iphone1.jpeg",
  price: 300,
  category: "Special Products",
  inCart:0,      
},
{
  id: 18,
  title: "Sony WH-CH510",
  image: "./images/products/headphone/headphone9.jpeg",
  price: 630,
  category: "Trending Products",
  inCart:0,
},
{
  id: 20,
  title: "Samsung Galaxy",
  image: "./images/products/sumsung/samsung4.jpeg",
  price: 270,
  category: "Special Products",
  inCart:0,      
},
{
  id: 19,
  title: "Sony WH-CH510",
  image: "./images/products/headphone/headphone10.jpeg",
  price: 250,
  category: "Trending Products",
  inCart:0,
},
{
  id: 1,
  title: "Sony WH-CH510",
  image: "./images/products/headphone/headphone1.jpeg",
  price: 265,
  category: "Special Products",
  inCart:0,      
},
{
  id: 24,
  title: "Samsung Galaxy",
  image: "./images/products/sumsung/samsung2.jpeg",
  price: 500,
  category: "Featured Products",
  inCart:0,
},
{
  id: 21,
  title: "Sony WH-CH510",
  image: "./images/products/headphone/headphone11.jpeg",
  price: 700,
  category: "Trending Products",
  inCart:0,
},

{
  id: 25,
  title: "Samsung Galaxy",
  image: "./images/products/sumsung/samsung1.jpeg",
  price: 450,
  category: "Special Products",
  inCart:0,      
},
{
  id: 22,
  title: "Samsung Galaxy",
  image: "./images/products/sumsung/samsung3.jpeg",
  price: 460,
  category: "Trending Products",
  inCart:0
},
{
  id: 23,
  title: "Sony WH-CH510",
  image: "./images/products/headphone/headphone12.jpeg",
  price: 600,
  category: "Featured Products",
  inCart:0
}
]

let cars = document.querySelectorAll('.product__btn');
for (let i = 0; i < cars.length; i++) {
  cars[i].addEventListener('click', () => {
    cartNumbers(products[i]);
    totalCost(products[i]);
  })
}
function onLoadCartNumbers() {
  let productNumbers = localStorage.getItem('cartNumbers');

  if( productNumbers) {
    document.querySelector('.icon__item span').textContent = productNumbers;
  }
}
function cartNumbers(product) {
  console.log("The product clicked",product)
  let productNumbers = localStorage.getItem('cartNumbers');
  productNumbers = parseInt(productNumbers);

  if(productNumbers ) {
    localStorage.setItem('cartNumbers',productNumbers +1);
    document.querySelector('.icon__item span').textContent = productNumbers + 1;   
  } else {
    localStorage.setItem('cartNumbers', 1);
    document.querySelector('.icon__item span').textContent = 1;
  }
  
  setItems(product);
}
function setItems(product){
  let cartItems = localStorage.getItem('productsInCart');
  cartItems = JSON.parse(cartItems);

  if(cartItems != null){
    if(cartItems[product.tag] == undefined) {
      cartItems = {
        ...cartItems,
        [product.tag]: product
      }
    }
    cartItems[product.tag].inCart += 1;
  } else {
    product.inCart = 1;
    cartItems = {
    [product.tag]: product
  }
  
  localStorage.setItem("productInCart",JSON.stringify(cartItems));
}
}
function totalCost(product) {
  // console.log("Product price is",product.price)
  let cartCost = localStorage.getItem("totalCost");
  

  if(cartCost != null){
    cartCost = parseInt(cartCost);
    localStorage.setItem("totalCost", cartCost + product.price)
  }else{
    localStorage.setItem("totalCost", product.price)
  }
  
}

function displayCart() {
  let cartItems = localStorage.getItem("productsInCart");
  cartItems = JSON.parse(cartItems);
  let productContainer = document.querySelector(".products-container");
  
  console.log(cartItems);

  if(cartItems && productContainer ) {
    productContainer.innerHTML = '';
    Object.values(cartItems)
    }
}
onLoadCartNumbers();
displayCart();

