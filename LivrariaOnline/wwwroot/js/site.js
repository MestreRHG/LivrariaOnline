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