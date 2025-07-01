tinymce.init({
    selector: '#tiny',  // ID của TextArea mà bạn muốn áp dụng TinyMCE
    plugins: [
        // Core editing features
        'anchor', 'autolink', 'charmap', 'codesample', 'emoticons', 'image', 'link', 'lists', 'media', 'searchreplace', 'table', 'visualblocks', 'wordcount',
        // Your account includes a free trial of TinyMCE premium features
        // Try the most popular premium features until Jul 15, 2025:
        'checklist', 'mediaembed', 'casechange', 'formatpainter', 'pageembed', 'a11ychecker', 'tinymcespellchecker', 'permanentpen', 'powerpaste', 'advtable', 'advcode', 'editimage', 'advtemplate', 'ai', 'mentions', 'tableofcontents', 'footnotes', 'mergetags', 'autocorrect', 'typography', 'inlinecss', 'markdown', 'importword', 'exportword', 'exportpdf'
    ],
    toolbar: 'undo redo | blocks fontfamily fontsize | bold italic underline strikethrough | link image media table | align lineheight | checklist numlist bullist indent outdent | emoticons charmap',

    images_upload_url: '/api/upload',  // URL để upload hình ảnh
    automatic_uploads: true,  // Tự động upload khi thêm hình
    file_picker_types: 'image',  // Loại file có thể chọn
    images_upload_handler: function (blobInfo, success, failure) {
        // Sử dụng API upload của bạn tại đây
        var formData = new FormData();
        formData.append('file', blobInfo.blob());

        fetch('/api/upload', {  // Cấu hình đường dẫn upload hình ảnh
            method: 'POST',
            body: formData
        })
            .then(response => response.json())
            .then(data => success(data.location))  // URL của hình ảnh sau khi upload
            .catch(err => failure('Upload failed: ' + err));
    }
});
