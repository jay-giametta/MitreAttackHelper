function jClearSelection() {
    $(document).find('.user-selected').removeClass('user-selected');
    $(document).find('.selected').removeClass('selected');
    $('#intrusion-set').val("blank");
}

function jCollapseToggle(domElement) {
    const id = $(domElement).attr('id');
    const parent = $(domElement).parent();
    const children = parent.find(`[data-parent='${id}']`).not('.parent');
    if (children.hasClass('collapse')) {
        children.removeClass('collapse');
    }
    else {
        children.addClass('collapse');
    }
}

function jIntrusionSelect(id) {
    $(document).find('.selected').removeClass('selected');
    if (id !== "blank") {
        $(document).ready(() => {
            $('#spinner').show();
            $.ajax({
                type: 'GET',
                url: `API/Mitre/Relationships/${id}/AttackPatternsUsed`,
                success: (attackPatternIds) => {
                    $('#spinner').hide();
                    JSON.parse(attackPatternIds).forEach((attackPatternId) => $(`#${attackPatternId}`).addClass('selected'));
                },
                failure: (error) => {
                    $('#spinner').hide();
                }
            });
        });
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
    const element = $(domElement).parent();
    if (element.hasClass('user-selected')) {
        element.removeClass('user-selected');
        userSelected = userSelected.filter((value) => {
            return value !== element.attr('id');
        });
    }
    else {
        element.addClass('user-selected');
        userSelected.push(element.attr('id'));
    }
    return false;
}