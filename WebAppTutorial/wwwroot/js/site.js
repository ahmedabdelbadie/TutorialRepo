// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function confirmDelete(uniqueId, isDeleteClick) {
    var deleteSpan = 'deletespan_' + uniqueId;
    var confirmDelete = 'deleteconfirmspan_' + uniqueId;
    if (isDeleteClick) {
        $('#' + deleteSpan).hide();
        $('#' + confirmDelete).show();

    } else {
        $('#' + deleteSpan).show();
        $('#' + confirmDelete).hide();
    }

}