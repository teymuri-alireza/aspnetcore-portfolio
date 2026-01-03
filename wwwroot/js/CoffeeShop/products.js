document.addEventListener("DOMContentLoaded", () => {
    const deleteAlert = document.getElementById("delete-alert");

    if (!deleteAlert) return;

    deleteAlert.style.transition = "opacity 0.6s ease, transform 0.6s ease";

    setTimeout(() => {
        deleteAlert.style.opacity = "0";
        deleteAlert.style.transform = "translateY(-10px)";

        // Remove from DOM after animation completes
        setTimeout(() => {
            deleteAlert.remove();
        }, 600);
    }, 2000);
});
