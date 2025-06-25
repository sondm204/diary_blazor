const lumexui = require("C:/Users/Son Duong/.nuget/packages/lumexui/1.1.1/theme/plugin");

module.exports = {
    darkMode: 'selector',
    content: [
        './wwwroot/index.html',
        './**/*.razor',
        './**/*.cshtml',
        'C:/Users/Son Duong/.nuget/packages/lumexui/1.1.1/theme/components/*.cs'
    ],
    theme: {
        extend: {},
        fontFamily: {
            'inter': ['Inter', 'sans-serif'],
        }
    },
    plugins: [lumexui],
}
