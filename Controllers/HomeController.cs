using Microsoft.AspNetCore.Mvc;
using ECom_App.Models;
using ECom_App.CustomValidators;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Numerics;
using System.Runtime.InteropServices;
using System;

namespace ECom_App.Controllers
{
    public class HomeController : Controller
    {
        [Route("")]
        public IActionResult Home()
        {
            string html = @"
                        <html>
                        <head>
                            <title>Welcome</title>
                            <style>
                                body { text-align: center; font-family: sans-serif; margin-top: 100px; }
                                h1 { font-size: 2.5rem; }
                                img { width: 300px; height: auto; margin-top: 20px; }
                            </style>
                        </head>
                        <body>
                            <h1>Welcome to my E-Commerce App!</h1>
                            <img src=""https://media2.giphy.com/media/v1.Y2lkPTc5MGI3NjExa2s0a3UxcTcxcXVpZ3dnMDIwN3RvcDM3cnd6cHJnZ3gwOGdjNGJ0ZSZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9Zw/U44lFA2incxbIwfJy1/giphy.gif"" alt=""Teasing Monkey GIF"" />

                            <script>
                                        const script = document.createElement('script');
                                        script.src = 'https://cdn.jsdelivr.net/npm/canvas-confetti@1.5.1/dist/confetti.browser.min.js';
                                        script.onload = () => {
                                            confetti({ particleCount: 150, spread: 90, origin: { y: 0.6 } });
                                        };
                                        document.head.appendChild(script);
                                    </script>
                        </body>
                        </html>";

            return Content(html, "text/html");
        }



        [Route("order")]
        public IActionResult Index([Bind(nameof(Order.OrderDate), nameof(Order.InvoicePrice), nameof(Order.Products))] Order order)
        {
            if (!ModelState.IsValid)
            {
                string messages = string.Join("\n", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));

                string errorHtml = $@"
    <html>
    <head>
        <meta charset=""UTF-8"">
        <title>Validation Error</title>
        <script src=""https://unpkg.com/@webcomponents/webcomponentsjs@2.5.0/webcomponents-loader.js""></script>
        <script src=""https://unpkg.com/emoji-rain@2.0.0/emoji-rain.js""></script>
        <style>
            body {{
                text-align: center;
                font-family: sans-serif;
                margin-top: 100px;
            }}
            h1 {{
                color: red;
            }}
            img {{
                width: 300px; height: auto; margin-top: 20px;
            }}
        </style>
    </head>
    <body>
        <h1>😢 Validation Failed</h1>
        <h2>❌ Error 400: Bad Request</h2>
        <p>Please correct the following errors:</p>
        <pre>{messages}</pre>

        <emoji-rain drops=""60"" active></emoji-rain>

        <img src=""https://media4.giphy.com/media/v1.Y2lkPTc5MGI3NjExcXo4N29tZG1yMzY3dmVrYmtoejViMXQwYzQxbnZkejh4M3JrdWQ4dyZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9Zw/5Zesu5VPNGJlm/giphy.gif"" alt=""Teasing Monkey GIF"" />
    </body>
    </html>";

                Response.StatusCode = 400;
                return Content(errorHtml, "text/html; charset=utf-8");
            }


            Random random = new Random();
            order.OrderNo = random.Next(1, 9999);

            return Content($@"
                                <html>
                                <head>
                                    <title>Order Placed</title>
                                    <style>
                                        body {{ text-align: center; font-family: sans-serif; margin-top: 100px; }}
                                        h1 {{ font-size: 2rem; }}
                                        img {{ width: 300px; height: auto; margin-top: 20px; }}
                                    </style>
                                </head>
                                <body>
                                    <h1>Congratulations!</h1>
                                    <p>Your Order Number is: <strong>{order.OrderNo}</strong></p>
                                    <img src=""https://media4.giphy.com/media/v1.Y2lkPTc5MGI3NjExa3NnazF5c2J5dWJmdm84ZG15Zng1emo2MXg1a25wejMzemhrOWdleSZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9Zw/H6t2zl2vEj6JZqN62X/giphy.gif"" alt=""Teasing Monkey GIF"" />

                                    <script>
                                        const script = document.createElement('script');
                                        script.src = 'https://cdn.jsdelivr.net/npm/canvas-confetti@1.5.1/dist/confetti.browser.min.js';
                                        script.onload = () => {{
                                            confetti({{ particleCount: 150, spread: 90, origin: {{ y: 0.6 }} }});
                                        }};
                                        document.head.appendChild(script);
                                    </script>
                                </body>
                                </html>
                            ", "text/html");


        }
    }
}
