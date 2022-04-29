function jCollapseToggle(parentId, tacticId) {
    const children = $(`#${tacticId}`).find(`[data-parent='${parentId}']`).not('.parent');
    if (children.hasClass('collapse')) {
        children.removeClass('collapse');
    }
    else {
        children.addClass('collapse');
    }
}

function jLoad(divId, url) {
    $(document).ready(() => {
        $('#spinner').show();
        $.ajax({
            type: 'GET',
            url: url,
            success: (result) => {
                $('#spinner').hide();
                $(`#${divId}`).html(result);
            },
            failure: () => {
                $('#spinner').hide();
            }
        });
    });
}

function jSelectToggle(domElement) {
    element = $(domElement).parent();
    if (element.hasClass('selected')) {
        element.removeClass('selected');
    }
    else {
        element.addClass('selected');
    }
    return false;
}