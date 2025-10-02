// custom-swal.js

// Confirm edit form submission
document.addEventListener("DOMContentLoaded", function () {
    const editForm = document.getElementById("editForm");
    if (editForm) {
        editForm.addEventListener("submit", function (e) {
            e.preventDefault(); // stop normal submit

            Swal.fire({
                title: 'Save Changes?',
                text: "Do you want to update this book?",
                icon: 'question',
                showCancelButton: true,
                confirmButtonColor: '#158cba',
                cancelButtonColor: '#6c757d',
                confirmButtonText: 'Yes, save it!'
            }).then((result) => {
                if (result.isConfirmed) {
                    e.target.submit(); // continue submit
                }
            });
        });
    }

    // Confirm delete form submission
    document.querySelectorAll('.delete-form').forEach(form => {
        form.addEventListener('submit', function (e) {
            e.preventDefault(); // stop normal form submit
            Swal.fire({
                title: 'Are you sure?',
                text: "This action cannot be undone.",
                icon: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#d33',
                cancelButtonColor: '#6c757d',
                confirmButtonText: 'Yes, delete it!'
            }).then((result) => {
                if (result.isConfirmed) {
                    form.submit(); // only submit if confirmed
                }
            });
        });
    });
});
