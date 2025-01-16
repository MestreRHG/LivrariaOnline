const isAuthenticated = User.Identity.IsAuthenticated.ToString().ToLower();
if (!isAuthenticated) {
        document.getElementById("guestHiddenButton").style.display = "none";
}