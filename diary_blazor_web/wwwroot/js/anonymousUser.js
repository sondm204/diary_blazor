window.createOrGetAnonymousUser = function () {
    let userId = localStorage.getItem("anonymousUserId");

    // Nếu không có userId, tạo một ID mới và lưu vào localStorage
    if (!userId) {
        userId = 'user-' + Math.random().toString(36).substr(2, 9); // Tạo ID ngẫu nhiên
        localStorage.setItem("anonymousUserId", userId);
    }

    return userId;
};