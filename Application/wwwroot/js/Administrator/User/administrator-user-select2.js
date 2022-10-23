$('#campo-hierarchy').select2({
    ajax: {
        url: '/administrator/users/getUserHierarchy',
        dataType: 'json',
        processResults: (data) => ({ results: data })
    }
});