import fs from 'node:fs'

const getDiff = (file1, file2) => {
    const oldFile = fs.readFileSync(file1, { encoding: "utf-8" })
    const newFile = fs.readFileSync(file2, { encoding: "utf-8" })
    const oldFileJS = JSON.parse(oldFile)
    const newFileJS = JSON.parse(newFile)
    return JSON.stringify(compareJSON(oldFileJS, newFileJS), null, 2)
}

function compareJSON(oldJson, newJson) {
    const result = {};

    for (let key in oldJson) {
        if (!(key in newJson)) {
            result[key] = {
                type: 'delete',
                oldValue: oldJson[key]
            };
        } else if (typeof oldJson[key] === 'object' && !Array.isArray(oldJson[key])) {
            if (typeof newJson[key] === 'object' && !Array.isArray(newJson[key])) {
                result[key] = compareJSON(oldJson[key], newJson[key]);
            } else {
                result[key] = {
                    type: 'changed',
                    oldValue: oldJson[key],
                    newValue: newJson[key]
                };
            }
        } else if (Array.isArray(oldJson[key])) {
            if (Array.isArray(newJson[key])) {
                if (oldJson[key].length !== newJson[key].length) {
                    result[key] = {
                        type: 'changed',
                        oldValue: oldJson[key],
                        newValue: newJson[key]
                    };
                } else {
                    result[key] = { type: 'unchanged', children: {} };
                    oldJson[key].forEach((item, index) => {
                        result[key].children[index] = {
                            type: item === newJson[key][index] ? 'unchanged' : 'changed',
                            oldValue: item,
                            newValue: item === newJson[key][index] ? null : newJson[key][index]
                        };
                    });
                }
            } else {
                result[key] = {
                    type: 'changed',
                    oldValue: oldJson[key],
                    newValue: newJson[key]
                };
            }
        } else {
            result[key] = {
                type: oldJson[key] === newJson[key] ? 'unchanged' : 'changed',
                oldValue: oldJson[key],
                newValue: oldJson[key] === newJson[key] ? null : newJson[key]
            };
        }
    }

    for (let key in newJson) {
        if (!(key in oldJson)) {
            result[key] = {
                type: 'new',
                newValue: newJson[key]
            };
        }
    }

    return result;
}


export default getDiff