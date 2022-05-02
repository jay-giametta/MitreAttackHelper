﻿function jClearSelection() {
    $(document).find('.user-selected').removeClass('user-selected');
    $(document).find('.selected').removeClass('selected');
    $('#intrusion-set').val("blank");
    userSelected = [];
}

function jCollapseToggle(domElement) {
    const id = $(domElement).attr('id');
    const children = $(document).find(`[data-parent='${id}']`).not('.parent');
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
                url: `API/Mitre/Relationships/Source/${id}/UsesAttackPatterns`,
                success: (attackPatternIds) => {
                    $('#spinner').hide();
                    JSON.parse(attackPatternIds).forEach((attackPatternId) => $(document).find(`[id='${attackPatternId}']`).addClass('selected'));
                    $('#intrusion-set').val(id);
                },
                failure: (error) => {
                    $('#spinner').hide();
                    jModalShow('/Modal/Error');
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
                jModalShow('/Modal/Error');
            }
        });
    });
}

function jMatchIntrusionSets() {
    $('#spinner').show();

    let matches = {};
    let promises = [];

    userSelected.forEach((selection) => {
        promises.push(new Promise((resolve, reject) => {
            $.ajax({
                type: 'GET',
                url: `API/Mitre/Relationships/Target/${selection}/UsedByIntrusionSets`,
                success: (intrusionSets) => {
                    JSON.parse(intrusionSets).forEach((intrusionSet) => {
                        if (matches[intrusionSet] !== undefined) {
                            matches[intrusionSet]++;
                        }
                        else {
                            matches[intrusionSet] = 1;
                        }
                    });
                    resolve();
                },
                failure: () => {
                    jModalShow('/Modal/Error');
                    reject();
                }
            });
        }));
    });

    Promise.all(promises).then(() => {
        $('#spinner').hide();
        jModalShow(`/Modal/IntrusionSetMatch?sets=${JSON.stringify(jSortDictionary(matches, 3))}`);
    });  
}

function jModalShow(url) {
    $.ajax({
        type: 'GET',
        url: url,
        success: (result) => {
            $('#modal').html(result);
            $('#modal').modal('show')
        }
    });
}

function jSelectToggle(domElement) {
    const id = $(domElement).parent().attr('id');
    const elements = $(document).find(`[id='${id}']`);
    if (elements.hasClass('user-selected')) {
        elements.removeClass('user-selected');
        userSelected = userSelected.filter((value) => {
            return value !== elements.attr('id');
        });
    }
    else {
        elements.addClass('user-selected');
        userSelected.push(elements.attr('id'));
    }
    return false;
}

function jSortDictionary(dictionary, take) {
    let toArray = Object.keys(dictionary).map((key) => {
        return [key, dictionary[key]];
    })

    toArray.sort((first, second) => {
        return second[1] - first[1];
    });

    if (take > toArray.length) {
        take = toArray.length;
    }

    toArray = toArray.slice(0, take);

    let returnDictionary = {};

    toArray.forEach((row) => returnDictionary[row[0]] = row[1])

    return returnDictionary;
}