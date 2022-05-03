function jClearFollowOns(){
    $(document).find('.selected').removeClass('selected');
    $(document).find('.attack').css('opacity', 1);
    $('#follow-ons').html('Show Potential Follow-on Attacks');
    $('#follow-ons').attr('href', 'javascript:jIdentifyFollowOns();');
}

function jClearSelection() {
    $(document).find('.user-selected').removeClass('user-selected');
    $(document).find('.selected').removeClass('selected');
    $(document).find('.attack').css('opacity', 1);
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

function jIdentifyFollowOns() {
    $('#spinner').show();

    let followOns = {};
    let promises = [];

    userSelected.forEach((selection) => {
        promises.push(new Promise((resolve, reject) => {
            $.ajax({
                type: 'GET',
                url: `API/Mitre/Relationships/Target/${selection}/UsedByIntrusionSets`,
                timeout: 10000,
                success: (intrusionSets) => {
                    let subPromises = [];
                    JSON.parse(intrusionSets).forEach((intrusionSet) => {
                        subPromises.push(new Promise((subResolve, subReject) => {
                            $.ajax({
                                type: 'GET',
                                url: `API/Mitre/Relationships/Source/${intrusionSet}/UsesAttackPatterns`,
                                timeout: 10000,
                                success: (attackPatterns) => {
                                    JSON.parse(attackPatterns).forEach((attackPattern) => {
                                        if (followOns[attackPattern] !== undefined) {
                                            followOns[attackPattern]++;
                                        }
                                        else {
                                            followOns[attackPattern] = 1;
                                        }
                                    });
                                    subResolve();
                                },
                                error: () => {
                                    subReject();
                                }
                            });
                        }));
                    });
                    Promise.all(subPromises).then(() => {
                        resolve();
                    }, () => {
                        reject();
                    });
                },
                error: () => {
                    reject();
                }
            });
        }));
    });

    Promise.all(promises).then(() => {
        $('#spinner').hide();
        let max = 0;
        Object.keys(followOns).forEach((key) => {
            if (followOns[key] > max) {
                max = followOns[key];
            }
        });

        if (max != 0) {
            $(document).find('.attack').not('.user-selected').css('opacity', 0);
            $('#follow-ons').html('Show All Attacks');
            $('#follow-ons').attr('href', 'javascript:jClearFollowOns();');
        }

        Object.keys(followOns).forEach((key) => {
            const element = $(document).find(`[id='${key}']`);
            const opacity = (followOns[key] / max).toFixed(3);
            element.addClass('selected');
            element.css('opacity', opacity);
        });

    }, () => {
        $('#spinner').hide();
        jModalShow('/Modal/Error');
    });
}

function jIntrusionSelect(id) {
    $(document).find('.selected').removeClass('selected');
    if (id !== "blank") {
        $(document).ready(() => {
            $('#spinner').show();
            $.ajax({
                type: 'GET',
                url: `API/Mitre/Relationships/Source/${id}/UsesAttackPatterns`,
                timeout: 10000,
                success: (attackPatternIds) => {
                    $('#spinner').hide();
                    JSON.parse(attackPatternIds).forEach((attackPatternId) => $(document).find(`[id='${attackPatternId}']`).addClass('selected'));
                    $('#intrusion-set').val(id);
                },
                error: (error) => {
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
            timeout: 10000,
            success: (result) => {
                $('#spinner').hide();
                $(`#${divId}`).html(result);
            },
            error: () => {
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
                timeout: 10000,
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
                error: () => {
                    reject();
                }
            });
        }));
    });

    Promise.all(promises).then(() => {
        $('#spinner').hide();
        jModalShow(`/Modal/IntrusionSetMatch?sets=${JSON.stringify(jSortDictionary(matches, 3))}`);
    }, () => {
        $('#spinner').hide();
        jModalShow('/Modal/Error');
    });
}

function jModalShow(url) {
    $('#spinner').show();
    $.ajax({
        type: 'GET',
        url: url,
        timeout: 10000,
        success: (result) => {
            $('#spinner').hide();
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