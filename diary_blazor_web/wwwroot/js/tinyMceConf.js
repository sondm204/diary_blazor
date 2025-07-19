window.initTinyMCE = (selector) => {
    if (typeof tinymce !== 'undefined') {
        if (tinymce.get(selector)) {
            tinymce.get(selector).remove();
        }
        tinymce.init({
            selector: 'textarea#editor',
            plugins: [
                'anchor', 'autolink', 'charmap', 'codesample', 'emoticons', 'image', 'link', 'lists',
                'media', 'searchreplace', 'table', 'visualblocks', 'wordcount',
            ],
            toolbar: 'undo redo | blocks fontfamily fontsize | bold italic underline strikethrough | link image media table mergetags | addcomment showcomments | spellcheckdialog a11ycheck typography | align lineheight | checklist numlist bullist indent outdent | emoticons charmap | removeformat',
            automatic_uploads: true,
            file_picker_types: 'image',
            images_upload_handler: function (blobInfo, progress) {
                return new Promise((resolve, reject) => {
                    const formData = new FormData();
                    formData.append('file', blobInfo.blob(), blobInfo.filename());

                    fetch('/api/upload', {
                        method: 'POST',
                        body: formData
                    })
                        .then(res => {
                            if (!res.ok) throw new Error("Upload failed with status " + res.status);
                            return res.json();
                        })
                        .then(data => {
                            if (data && data.location) {
                                resolve(data.location);
                            } else {
                                reject("Server did not return a location");
                            }
                        })
                        .catch(err => {
                            reject({
                                message: "Upload failed: " + err.message,
                                remove: true
                            });
                        });
                });
            }

        });
    }
};

window.getTinyMCEContent = (selector) => {
    if (tinymce.get(selector)) {
        return tinymce.get(selector).getContent();
    }
    return "";
};
