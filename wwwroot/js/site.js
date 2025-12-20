// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const glowCursor = document.getElementById("glow-cursor");

document.addEventListener("mousemove", (e) => {
    glowCursor.style.transform = `translate(${e.clientX}px, ${e.clientY}px)`;
});
