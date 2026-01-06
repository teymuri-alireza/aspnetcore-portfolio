const menuToggle = document.getElementById("menuToggle");
const navLinks = document.getElementById("navLinks");
const toTop = document.getElementById("toTop");
const anchors = navLinks.querySelectorAll("a");
const form = document.getElementById("reserveForm");
const formMessage = document.getElementById("formMessage");

menuToggle.addEventListener("click", () => {
    navLinks.classList.toggle("open");
});

anchors.forEach((link) => {
    link.addEventListener("click", () => {
    navLinks.classList.remove("open");
    anchors.forEach((a) => a.classList.remove("active"));
    link.classList.add("active");
    });
});

window.addEventListener("scroll", () => {
    if (window.scrollY > 180) {
    toTop.classList.add("show");
    } else {
    toTop.classList.remove("show");
    }
});

toTop.addEventListener("click", () => {
    window.scrollTo({ top: 0, behavior: "smooth" });
});

form.addEventListener("submit", (e) => {
    e.preventDefault();
    form.reset();
    formMessage.style.display = "block";
    setTimeout(() => { formMessage.style.display = "none"; }, 3200);
});