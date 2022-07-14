
//For Go To  Top Button
console.log("Chalena");
const goToTopBtn = document.querySelector('#goToTop');

window.addEventListener("scroll", scrollFunction);

function scrollFunction() {
    if (document.body.scrollTop > 20 || document.documentElement.scrollTop > 20) {
       
        goToTopBtn.style.display = "block";

    } else {
        goToTopBtn.style.display = "none";
    }
}
function goTop() {
    window.scroll(0, 0);
}


let navbar = document.querySelector('.navbar');



document.querySelector('#menu-btn').onclick = () => {

    navbar.classList.toggle('active');

}



window.onscroll = () => {

    navbar.classList.remove('active');

}



let slides = document.querySelectorAll('.home .slides-container .slide');

let index = 0;



function next(){

    slides[index].classList.remove('active');

    index = (index + 1) % slides.length;

    slides[index].classList.add('active');

}



function prev(){

    slides[index].classList.remove('active');

    index = (index - 1 + slides.length) % slides.length;

    slides[index].classList.add('active');

}