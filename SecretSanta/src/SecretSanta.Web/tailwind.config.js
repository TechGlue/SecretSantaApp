module.exports = {
    purge: ['./**/*.html', './**/*.cshtml'],
    theme: {
        extend: {
            backgroundImage: them => ({
                'shook-girl': "url('DesignAssets/HomePageAssests/circle-surprised-woman.png')",
            }),
            colors:
            {
                'baby-blue-lighter': '#DEECFC',
                'baby-blue': '#B9CEEB',
                'baby-blue-dark': '#87A8D0',
                'christmas-green':'#5B8C5A',
                'christmas-red': "#90303D",
                'gold': "#FFDF6B",
                'gold2': "#FCD47D"
            },
            animation:{
                blob: "blob 7s infinite",
            },
            keyframes:{
                blob:{
                    "0%":
                    {
                        transform:"translate(0px, 0px) scale(1)",
                    },
                    "33%":
                    {
                        transform:"translate(30px, -50px) scale(1.1)",
                    },
                    "66%":
                    {
                        transform:"translate(-20px, 20px) scale(0.9)",
                    },
                    "100%":
                    {
                        transform:"translate(0px, 0px) scale(1)",
                    },
                    
                }
            }
        }
    },
    variants: {
    },
    plugins: []
}