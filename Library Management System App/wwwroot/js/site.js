$(document).ready(function () {
    // Reset letter animations
    $('.library-title .letter').css('animation', 'none');
    setTimeout(function () {
        $('.library-title .letter').each(function (index) {
            $(this).css('animation', `letterRipple 0.15s ease-out ${0.1 + index * 0.05}s forwards`);
        });
    }, 100);

    // Initialize Typed.js for subtitle
    if ($('.library-subtitle').length) {
        new Typed('.library-subtitle', {
            strings: [
                'Manage your books, borrowers, and records with ease.',
                'Streamline your library operations.',
                'Discover a world of knowledge.'
            ],
            typeSpeed: 50,
            backSpeed: 30,
            backDelay: 2000,
            loop: true,
            showCursor: true,
            cursorChar: '|'
        });
    }
});
