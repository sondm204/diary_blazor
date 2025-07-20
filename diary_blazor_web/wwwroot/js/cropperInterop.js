let cropper;
window.cropperInterop = {
    initCropper: function (imageId) {
        const image = document.getElementById(imageId);
        if (!image) return;

        if (cropper) {
            cropper.destroy();
            cropper = null;
        }
        image.onload = () => {
            cropper = new Cropper(image, {
                aspectRatio: 1,
                viewMode: 1,
                autoCropArea: 1,
                responsive: true
            });
        };
        if (image.complete && image.naturalHeight !== 0) {
            image.onload(); // gọi thủ công
        }

    },
    getCroppedImage: function () {
        if (!cropper) {
            console.error("Cropper not initialized!");
            return Promise.resolve(null);
        }

        const canvas = cropper.getCroppedCanvas({
            imageSmoothingEnabled: true,
            imageSmoothingQuality: 'high',
            maxWidth: 1024, // Limit max width
            maxHeight: 1024 // Limit max height
        });

        if (!canvas) {
            console.error("Canvas not created!");
            return Promise.resolve(null);
        }

        return new Promise((resolve) => {
            canvas.toBlob(
                (blob) => {
                    const reader = new FileReader();
                    reader.onloadend = () => resolve(reader.result);
                    reader.readAsDataURL(blob);
                },
                'image/jpeg',
                0.2
            );
        });
    }

};