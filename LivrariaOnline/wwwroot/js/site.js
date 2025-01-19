// Function to make it so the update status button on the deliveries page updates the value on the DB
function updateDeliveryStatus(deliveryId, checkbox) {
    var hasArrived = checkbox.checked;

    fetch(`/api/${deliveryId}/status`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ hasArrived: hasArrived })
    })
    .then(response => {
            if (!response.ok) {
                alert('Failed to update delivery status');
            }
    })
    .catch(error => {
            console.error('Error:', error);
            alert('Failed to update delivery status');
    });
}

/* Back to Top Button */
// Get the button
const backToTopButton = document.getElementById("backToTop");

// Show the button when scrolling down
window.onscroll = function () {
    if (document.body.scrollTop > 200 || document.documentElement.scrollTop > 200) {
        backToTopButton.style.display = "block";
    } else {
        backToTopButton.style.display = "none";
    }
};

// Scroll to the top when the button is clicked
backToTopButton.onclick = function () {
    window.scrollTo({
        top: 0,
        behavior: "smooth" // Smooth scrolling effect
    });
};