function deleteCategory(id) {
    if (confirm('Are you sure you want to delete this category?')) {
        var form = document.createElement('form');
        form.method = 'post';
        form.action = '/AdminPages/DeleteCategory/' + id;
        document.body.appendChild(form);
        form.submit();
    }
}