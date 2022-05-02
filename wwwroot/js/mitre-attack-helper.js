﻿function jCollapseToggle(domElement) {
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
    $(document).ready(() => {
        $('#spinner').show();
        $.ajax({
            type: 'GET',
            url: `API/Mitre/Relationships/${id}/AttackPatternsUsed`,
            success: (attackPatternIds) => {
                $('#spinner').hide();
                jClearSelection();
                JSON.parse(attackPatternIds).forEach((attackPatternId) => $(`#${attackPatternId}`).addClass('selected'));
            },
            failure: (error) => {
                $('#spinner').hide();
            }
        });
    });
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
    if (element.hasClass('selected')) {
        element.removeClass('selected');
    }
    else {
        element.addClass('selected');
    }
    return false;
}

function jClearSelection() {
    $(document).find('.selected').removeClass('selected');
    $('#result-info-display').html('Showing Results for User Selection');
}