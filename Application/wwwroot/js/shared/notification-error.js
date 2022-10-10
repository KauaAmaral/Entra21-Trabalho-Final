let showNotificationErrorsOfValidation = (errors) => {
    toastr.clear();

    for (let [_, value] of Object.entries(errors)) {
        toastr.error(value[0]);
    }
}