const lumexui = require("C:/Users/Son Duong/.nuget/packages/lumexui/1.1.1/theme/plugin");
const lineClamp = require('@tailwindcss/line-clamp');
// npx tailwindcss -i ./styles.css -o ./wwwroot/css/output.css --watch
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
    plugins: [lumexui, lineClamp],
}
