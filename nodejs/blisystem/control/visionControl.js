'use strict';
const vision = require('@google-cloud/vision/v1');
const client = new vision.ImageAnnotatorClient();


function detectLabels(fileName) {
    /**
     * TODO(developer): Uncomment the following line before running the sample.
     */
    // const fileName = 'Local image file, e.g. /path/to/image.png';

    // Performs label detection on the local file
    client
        .labelDetection(fileName)
        .then(results => {
            const labels = results[0].labelAnnotations;
            console.log('Labels:');
            labels.forEach(label => console.log(label));
        })
        .catch(err => {
            console.error('ERROR:', err);
        });
    // [END vision_label_detection]
}

function detectFulltext(fileName) {
    // [START vision_fulltext_detection]

    // Imports the Google Cloud client library
    const vision = require('@google-cloud/vision');

    // Creates a client
    const client = new vision.ImageAnnotatorClient();

    /**
     * TODO(developer): Uncomment the following line before running the sample.
     */
    // const fileName = 'Local image file, e.g. /path/to/image.png';

    // Read a local image as a text document
    client
        .documentTextDetection(fileName)
        .then(results => {
            const fullTextAnnotation = results[0].fullTextAnnotation;
            console.log(`Full text: ${fullTextAnnotation.text}`);

            fullTextAnnotation.pages.forEach(page => {
                page.blocks.forEach(block => {
                    console.log(`Block confidence: ${block.confidence}`);
                    block.paragraphs.forEach(paragraph => {
                        console.log(`Paragraph confidence: ${paragraph.confidence}`);
                        paragraph.words.forEach(word => {
                            const wordText = word.symbols.map(s => s.text).join('');
                            console.log(`Word text: ${wordText}`);
                            console.log(`Word confidence: ${word.confidence}`);
                            word.symbols.forEach(symbol => {
                                console.log(`Symbol text: ${symbol.text}`);
                                console.log(`Symbol confidence: ${symbol.confidence}`);
                            });
                        });
                    });
                });
            });
        })
        .catch(err => {
            console.error('ERROR:', err);
        });
    // [END vision_fulltext_detection]
}


function detectWeb(fileName) {

    /**
     * TODO(developer): Uncomment the following line before running the sample.
     */
    // const fileName = 'Local image file, e.g. /path/to/image.png';

    // Detect similar images on the web to a local file
    client
        .webDetection(fileName)
        .then(results => {
            const webDetection = results[0].webDetection;

            if (webDetection.fullMatchingImages.length) {
                console.log(
                    `Full matches found: ${webDetection.fullMatchingImages.length}`
                );
                webDetection.fullMatchingImages.forEach(image => {
                    console.log(`  URL: ${image.url}`);
                    console.log(`  Score: ${image.score}`);
                });
            }

            if (webDetection.partialMatchingImages.length) {
                console.log(
                    `Partial matches found: ${webDetection.partialMatchingImages.length}`
                );
                webDetection.partialMatchingImages.forEach(image => {
                    console.log(`  URL: ${image.url}`);
                    console.log(`  Score: ${image.score}`);
                });
            }

            if (webDetection.webEntities.length) {
                console.log(`Web entities found: ${webDetection.webEntities.length}`);
                webDetection.webEntities.forEach(webEntity => {
                    console.log(`  Description: ${webEntity.description}`);
                    console.log(`  Score: ${webEntity.score}`);
                });
            }

            if (webDetection.bestGuessLabels.length) {
                console.log(
                    `Best guess labels found: ${webDetection.bestGuessLabels.length}`
                );
                webDetection.bestGuessLabels.forEach(label => {
                    console.log(`  Label: ${label.label}`);
                });
            }
        })
        .catch(err => {
            console.error('ERROR:', err);
        });
    // [END vision_web_detection]
}

function detectAll(fileName) {
    client
        .labelDetection(fileName)
        .webDetection()
        .then(results => {
            console.log(results);
        })
        .catch(err => {
            console.error('ERROR:', err);
        });
}

module.exports = {
    detectLabels: detectLabels,
    detectFulltext: detectFulltext,
    detectWeb: detectWeb,
    detectAll: detectAll
};