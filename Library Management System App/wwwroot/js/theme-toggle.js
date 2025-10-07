const toggleBtn = document.getElementById("themeToggle");

function applyTheme(isDark) {
    if (isDark) {
        document.body.classList.add("dark-mode");
        toggleBtn.innerHTML = '<i class="bi bi-sun-fill"></i> Light Mode';
        toggleBtn.classList.remove("btn-outline-secondary");
        toggleBtn.classList.add("btn-outline-light");
        toggleBtn.style.color = "white"; // ✅ Force white text
    } else {
        document.body.classList.remove("dark-mode");
        toggleBtn.innerHTML = '<i class="bi bi-moon-fill"></i> Dark Mode';
        toggleBtn.classList.remove("btn-outline-light");
        toggleBtn.classList.add("btn-outline-secondary");
        toggleBtn.style.color = ""; // Reset to default
    }
}

// Handle click
toggleBtn.addEventListener("click", () => {
    const isDark = !document.body.classList.contains("dark-mode");
    applyTheme(isDark);
    localStorage.setItem("theme", isDark ? "dark" : "light");
});

// Load saved theme
const savedTheme = localStorage.getItem("theme");
applyTheme(savedTheme === "dark");
