let cartIcon=document.getElementById("cart-icon");
let cart=document.querySelector(".cart");
let closeCart=document.querySelector("#close-cart");

console.log('1');
cartIcon.onclick = () => {
    alert("message");
};
//cartIcon.onclick=()=>{
//    cart.classList.add("active");
//};

closeCart.onclick=()=>{
    cart.classList.remove("active");
};


if(document.readyState=='loading')
{
    document.addEventListener('DOMContentLoaded',ready);
}
else{
    ready();
}

function ready(){
    var removeCartButtons=document.getElementsByClassName('cart-remove')
    console.log(removeCartButtons)
    for(var i=0;i<removeCartButtons.length;i++){
        var button =removeCartButtons[i];
        button.addEventListener('click', removeCartitems);
    }
    //quantity changes
    var quantityinputs=document.getElementsByClassName('cart-qty');
    for(var i=0;i<quantityinputs.length;i++){
    var input=quantityinputs[i]
    input.addEventListener("change",quantityChanged);
    }
    //add to cart
    var addCart=document.getElementById('add-cart')
    for(var i=0;i<addCart.length;i++){
        var button =addCart[i]
        button.addEventListener('click',addCartClicked)
    
    }

}


//remove item from cart
function removeCartitems(event)
{
    var buttonClicked=event.target;
    buttonClicked.parentElement.remove();
    updatetotal();
}
//quantity changes

function quantityChanged(event){
    var input=event.target;
    if(isNaN(input.value)||input.value<=0){
        input.value=1;
    }
    updatetotal();
}
//add to cart

function addCartClicked(event){
    var button=event.target
    var shopProducts=button.parentElement
    var title=shopProducts.getElementsByClassName('product-title')[0].innerText
    var price=shopProducts.getElementsByClassName('price')[0].innerText
    var productImg=shopProducts.getElementsByClassName('product-img')[0].src
    addProductToCart(title,price,productImg); 
    updatetotal();
}

function addProductToCart(title,price,productImg){
    var cartShopbox=document.createElement("div");
    cartShopbox.classList.add("cart-box");
    var cartItems=document.getElementsByClassName('cart-content')[0];
    var cartItemsNames=cartItems.getElementsByClassName('cart-product-title');
    for(var i=0;i<cartItemsNames.length;i++){
        alert('you have already add this item to the cart');
        return;
    }
}
    var cartBoxContent=`<img src="anime-sky-4k-0f-1920x1080.jpg" class="cart-img">
    <div class="detail-box">
    <div class="cart-product-title">Donut</div>
    <div class="cart-price">10</div>
    <input type="number" value="1" class="cart-qty">
    </div>
    <i class='bx bxs-trash-alt cart-remove' id="cart-remove"></i>`;
    
    cartShopbox.innerHTML=cartBoxContent;
    cartItems.append(cartShopbox)
    cartShopbox.getElementsByClassName('cart-remove')[0].addEventListener('click',removeCartitems)
    cartShopbox.getElementsByClassName('cart-qty')[0].addEventListener('change',quantityChanged)
//update total
function updatetotal(){
    var cartContent =document.getElementsByClassName('cart-content')[0];
    var cartboxes=cartContent.getElementsByClassName('cart-box')
    var total=0;
    for(var i=0;i<cartboxes.length;i++){
        var cartbox=cartboxes[i]
        var priceElement = cartbox.getElementsByClassName('cart-price')[0]
        var quantityElement=cartbox.getElementsByClassName('cart-qty')[0]
        var price=parseFloat(priceElement.innerText.replace("Rs",""));
        var quantity =quantityElement.value
        total=total+price*quantity;

        //if price in decimal
            total=Math.round(total*100)/100;
        document.getElementsByClassName('total-price')[0].innerText='Rs'+total;
    }
}