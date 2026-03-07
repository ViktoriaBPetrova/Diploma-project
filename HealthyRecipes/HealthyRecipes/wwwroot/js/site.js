// NutriTrack — site.js

// Auto-dismiss alerts after 4s
document.addEventListener('DOMContentLoaded', () => {
    const alerts = document.querySelectorAll('.alert');
    alerts.forEach(alert => {
        setTimeout(() => {
            alert.style.transition = 'opacity 0.5s';
            alert.style.opacity = '0';
            setTimeout(() => alert.remove(), 500);
        }, 4000);
    });

    // Star rating interactivity (hover effect for ratings not supported natively in CSS for radio groups without JS)
    const ratingInputs = document.querySelectorAll('.rating-select input[type="radio"]');
    ratingInputs.forEach(input => {
        input.addEventListener('change', () => {
            const labels = document.querySelectorAll('.rating-select label');
            const val = parseInt(input.value);
            labels.forEach((label, i) => {
                // labels are reversed (5 to 1)
                const labelVal = 5 - i;
                label.style.filter = labelVal <= val ? 'none' : 'grayscale(1)';
            });
        });
    });
});
