'use strict';
const filter = require("array-filter");
/**
 * 結果データを抽出する
 * @param {JSON} rawData 画像認識結果の生データ
 * @return {JSON} 不要な情報を除去したデータ
 */
function filterResult(rawData) {
    if (!rawData || !rawData.responses || rawData.responses.length === 0) {
        return {
            bestGuess: '画像認識できません'
        };
    }
    let response = rawData.responses[0];
    let bestGuessLabels, logoAnnotations,labelAnnotations, webEntities,
        pagesWithMatchingImages, fullMatchingImages, partialMatchingImages, visuallySimilarImages,
        fullTextAnnotation;
    if (response.webDetection && response.webDetection.bestGuessLabels) {
        bestGuessLabels = filter(response.webDetection.bestGuessLabels, lable => lable.label);
    }
    if (response.logoAnnotations) {
        logoAnnotations = getValidityAnnotations(response.logoAnnotations);
    }
    if (response.labelAnnotations) {
        labelAnnotations = response.labelAnnotations.map(x => {
            return {
                score: x.score,
                description: x.description
            };
        });
        labelAnnotations = getValidityAnnotations(labelAnnotations);
    }
    if (response.webDetection && response.webDetection.webEntities) {
        webEntities = response.webDetection.webEntities.map(x => {
            return {
                score: x.score,
                description: x.description
            };
        });
        webEntities = getValidityAnnotations(webEntities);
    }
    if (response.webDetection && response.webDetection.pagesWithMatchingImages) {
        pagesWithMatchingImages = response.webDetection.pagesWithMatchingImages;
    }
    if (response.webDetection && response.webDetection.fullMatchingImages) {
        fullMatchingImages = response.webDetection.fullMatchingImages;
    }
    if (response.webDetection && response.webDetection.partialMatchingImages) {
        partialMatchingImages = response.webDetection.partialMatchingImages;
    }
    if (response.webDetection && response.webDetection.visuallySimilarImages) {
        visuallySimilarImages = response.webDetection.visuallySimilarImages;
    }
    if (response.fullTextAnnotation && response.fullTextAnnotation.text) {
        fullTextAnnotation = response.fullTextAnnotation.text;
    }
    return {
        logoAnnotations: logoAnnotations,
        bestGuessLabels: bestGuessLabels,
        labelAnnotations: labelAnnotations,
        webEntities: webEntities,
        pagesWithMatchingImages: pagesWithMatchingImages,
        fullMatchingImages: fullMatchingImages,
        partialMatchingImages: partialMatchingImages,
        visuallySimilarImages: visuallySimilarImages,
        fullTextAnnotation: fullTextAnnotation
    };
}
/**
 * 空のAnnotationsタグを除去
 * @param {annotation[]} annotations labelAnnotations|bestGuessLabels|webEntities
 * @return {annotation[]} 除去済みannotation配列
 */
function getValidityAnnotations(annotations) {
    if (!annotations) {
        return null;
    }
    let lables = filter(annotations, lable => lable.description);
    return lables;
}
/**
 * Annotationsタグのラベルを空白で連結する
 * @param {any} annotations  labelAnnotations|bestGuessLabels|webEntities
 * @return {string} 連結文字列
 */
function joinAnnotations(annotations) {
    let labels = annotations.map(label => {
        return label.description;
    }).join(' ');
    return labels;
}

/**
 * Query式を生成する
 * @param {any} resultData 結果データ
 * @return {string[]} Query単語配列
 */
function getQueryWords(resultData) {
    let contents = [];
    let bestGuessLabels = resultData.bestGuessLabels;
    if (bestGuessLabels) {
        let lables = bestGuessLabels.map(label => {
            return label.label;
        }).join(' ');
        contents.push(lables);
    }
    let labelAnnotations = resultData.labelAnnotations;
    if (labelAnnotations) {
        contents.push(joinAnnotations(labelAnnotations));
    }
    let webEntities = resultData.webEntities;
    if (webEntities) {
        contents.push(joinAnnotations(webEntities));
    }
    if (resultData.fullTextAnnotation) {
        contents.push(resultData.fullTextAnnotation);
    }
    let pagesWithMatchingImages = resultData.pagesWithMatchingImages;
    if (pagesWithMatchingImages) {
        let pages = filter(pagesWithMatchingImages, pages => {
            return pages.pageTitle && pages.pageTitle.match(/ricoh/gi); 
        });
        if (pages.length > 0) {
            contents.push(pages[0].pageTitle);
        }
    }
    let document = contents.join(' ');
    let words = convertContentsToWords(document);
    return words;
}

/**
 * 文字列を単語へ変換する（重複単語とHTMLタグを除去済み）
 * @param {string} context 文字列
 * @returns {string[]} 単語配列
 */
function convertContentsToWords(context) {
    if (!context) {
        return '';
    }
    context = context.trim().toLowerCase();
    let words = context.replace(/\<[^>]*\>/g, "").split(/\W+/g);
    let uniqueWords = Array.from(new Set(words));
    uniqueWords = uniqueWords.filter(x => x && x.trim() !== '');
    return uniqueWords;
}

function getCategoryWords(resultData) {
    let contents = [];
    let bestGuessLabels = resultData.bestGuessLabels;
    if (bestGuessLabels) {
        let lables = bestGuessLabels.map(label => {
            return label.label;
        }).join(' ');
        contents.push(lables);
    }
    let labelAnnotations = resultData.labelAnnotations;
    if (labelAnnotations) {
        contents.push(joinAnnotations(labelAnnotations));
    }
    let document = contents.join(' ');
    return document;
}




module.exports = {
    filterResult: filterResult,
    getQueryWords: getQueryWords,
    getCategory: getCategoryWords 
};