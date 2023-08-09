function showDeleteConfirmation(event, buttonText) {
    event.preventDefault();

    Swal.fire({
        title: 'Сигурни ли сте?',
        text: 'Искате ли да изтриете този запис? Данните Ви ще бъдат загубени!',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#d33',
        cancelButtonColor: '#3085d6',
        confirmButtonText: buttonText,  // Use the provided buttonText directly
        cancelButtonText: 'Отказ',
        allowEscapeKey: false,  // Prevent closing with Esc key
        allowOutsideClick: false,  // Prevent closing by clicking outside
    }).then((result) => {
        if (result.isConfirmed) {
            window.location.href = event.target.href;
        }
    });
}