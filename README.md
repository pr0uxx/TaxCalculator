# 🎊 UK Income Tax Calculator 🎊
## ‼️ DISCLAIMER: In no way does this actually calculate proper income tax ‼️

## About

This is a fun income tax calculator app! There is a database that stores tax bands per year and per country, a backend to do 
some of the more heavy lifting and a user interface so that you can use the app more easily!

The API backend uses swagger if you don't want to use the interface.

## Pre-requisites

- [node v16.16.0](https://nodejs.org/en/download/)
- [npm v 8.3.0](https://docs.npmjs.com/downloading-and-installing-node-js-and-npm)
- [.NET 6.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)

## Usage
Before starting the website, please run navigate to 'TaxCalculator.Client' directory in your command line and run  `npm install`.

(I highly recommend using visual studio. If you're not using visual studio, the rest might not apply to you.)

Once you've done that, open the solution in visual studio and press 'Start'. This should run both the UI and the backend. You should have a window open swagger and another window open the angular UI.

If that didn't work, in solution explorer, right click solution and click 'properties' in the context menu. Navigate to 'Startup Project'. From here, select 'multiple startup projects' and make sure the action dropdown is set to 'Start' for both TaxCalculator.Api and TaxCalculator.Client. All of the other dropdowns should be set to none.

## Solution plan
Below is my initial plan for the MVP solution:
[Plan Flowchart](/tax_calculator_design.png)

You can properly view the plan flowchart if you click [this mysterious link](https://viewer.diagrams.net/?tags=%7B%7D&highlight=0000ff&edit=_blank&layers=1&nav=1&title=tax_calculator_design.drawio#R7V1Zc%2BK4Fv41VPU8JOWV5TGQ5TKdnumbpeb2U5diK%2BBpYzG26ED%2F%2BntkW8a2ZHDwRhi6qhN8kLezfGeTlJ4%2BWazvfLScfyE2dnuaYq97%2BnVP09ShMoRfjLKJKMZQjQgz37HjQVvCo%2FMLx0Qlpq4cGweZgZQQlzrLLNEinoctmqEh3ydv2WGvxM3edYlmWCA8WsgVqX85Np1H1KE22NL%2Fg53ZnN9Z7Y%2BibxaID47fJJgjm7ylSPpNT5%2F4hNDo02I9wS5jHudLdN5twbfJg%2FnYo2VOQEtj%2BjlwgilVzYGJXtf%2FPH%2B%2F6MeX%2BYncVfzGtz7xKPZsoF7A%2FytvtnKRH78D3XDGBG%2FOwkUeHI3FJ%2BFXxT7F6xQpfrI7TBaY%2BhsYEn97MYq5FKvJID582%2FLc5EPmKX6bekxEsZxnyaWTuz2AXiBvBg%2Be3M7I3k3VxNupuuR2mp69G3Ip9j1E8ZisPDtI8x8%2BpF50SwqlIpfQevr99%2B%2F%2Fff7lTJ%2Bm9%2BuXm4fpdHih9gXWYxtUND4kPp2TGfGQe7Oljn32OJhdVoGj7Zh7QpZAVIH4N6Z0E9sbWlECpDlduPG3IEl%2F8z92%2FuXA5Mff0l9er%2BOrR0eb%2BCigyKdXzPCA4JFQP0LarcPeOxwTvRB7i0JV3qmsAVn5Ft4xMJYS3HaG6S7eynXSxy6izs%2Fs08kULCPrdwt2IJjeAw6WxAuYol4jiqSCv0cvALEZYSHXmXnw2QL2YR8IzO4cwLCr%2BIuFY9uRXuDA%2BYVewusxSSyJ49Hwxcxxz7xOZCMYbgKw8clbWEtLbYcCF1u%2Bcqn29WHGHi%2B06LC0IOKrf2WvkxpCXl8DUIBqVrlLw1Kye0JrIEyQawFcUgKA2XeBLeMX9mnGPj1i%2F6cDepuXatZY3%2BYOxY9LFCr4GzjVrKzfaSrlEVgfZDFRVySYqEkwsb8DgSsZiNEx8GVwT9mDezYK5uF91TYATmsJ4MJTAc3RJjUgBg3R7LgmmTnvqig5XYiuWKubNM%2FKUlVZtC6UZdSBrqijowqp9mlLJqSyXBQEjpWLqqLr2%2BIgIKaGnIyqVfIrmpjz8Lz1xfFsx5udSOA12unwIe4aqBnjO%2FqoSysRdSkTsoAgmrHmOAMtVd2b6jYWZ0lfwTBkbOU8dYj3gP9Z4UDkZ6oE8Eo8yvGTMdeaO659jzZkxZ4eoMr6wY%2FGc%2BI7v2A84qwOkSzGTa3PrgaQNSEuiDPJIbcnPbKLxbcJzQp%2F5UJSc6QvaJ0ZeI8Cyh%2BQuC5aBk5kVezEBYCW440JpWTRSyeqTQTbuQKEIQu2hxIlUBWjKS0wBS3oaWP2iBiBHK7gk7davGCxEgTvTEMp%2BuQHzolNIkkOmi5%2BpRLIpMydjgOwSwDi%2B3DMtbGlPMS8YCQC5766ocebA9BiL3TTFNFCoB0DSycsWAPI1SZwrG6PQxRegmOfQApOfeSEMsegMm9M%2BUtrQ2JO%2B7WB426%2FnPD5uPpl3y%2BQvQWIGUL2VShyX%2BYbz%2BKvKH5T61r8YiUqEv%2FMJ0Fw5XkrQF3kIq4IZxxoRhEGw64VYSiNfBtOjDLZMF47NJVRw9G31DfbDIkd8ATpnW76kPLxTgnnEqqqKbSQIyehHy%2FN5UPB6I3is%2BpvQYhhd1SdVv5c0eWK1h1zS3KgkrItjreyDEy6i53VNjtu6mTKD5daUo4oqEBI1fxAiyuuU5awOL0R%2B9Jz6qFrObFHzyXYV9XCqK6aOUVqotilCNb7HDDvrTheaLynUOrY22LSDDUG60N1hfvo7Am11DrkcuvEFyfuN%2BV8t65Y7n4b7RW3XNWshE6dFNA1JVdBH7VQQddEULlZODR8Wd7CPgVciYxwZ%2B96ONIz%2FOfachRV1F3qnJLdNPIEyi3xFx8gmhOaRv2uS6h9MUQeI%2BvHdhYVXBbURPkLv8DPq69T%2BPnpj5un%2Fm8Ci%2BudV2X29xabRwMJpw6cV2XmW7%2BSiVUJYLU3sUoeS4oFz2mq7i2bwfFpykDqFRRelFsjzQXtvfIWMp3OZ3FoXc9f%2B2i9Vk2MSuT6OyoZlpiKXGVq77bufMy0mT3gJQkcMDG4fB8tmHGElgbmN0YMM2PibFtuOzpLG%2BQsbSQxNLNNH2RKYrLbU%2BS0tHrTKqslUzefP089Cy6f8SDJjD%2FBkUyIZ%2FmYMtc5YQByrP5EH432%2BxNZjbo5f9LxTK9s6Wxf5ewj%2BZPSRbiCeSXtzN7Rxam3XShETbWLemYCVhGxnMlVSxnVQgYxQ73DFJAV8tO7sCW5YH3pq2DjWZ%2BOFjmHWeSUxAfSTKg54BSn%2BXRuOMeNiGpZc9Gq9iWqCbbr6aynmmGVl39BmbAduFRlBT0eixJgPnFdLKtmAKgeK3rm6xitrkaRO6XBCcadtQcYZskYkmdQTU%2BdyK9qSibf7mnt1lZk5JrfrdOtHRkHJeXMQ7n65FzNiGUTHU9AHKVTN7Mrccg7UR0v8WsQU%2BsJS%2BRc08qCbLfCFaEvtb55gqx5LUthD%2BovFqS3vIt1bCthJQlxF4ZznKH7joysTKWjrebIzsdMh%2B7fMPLdzRP5AqH73N2UqSbX25ZswKIMZb9JJWX9dkzqOCKBj2RSw7ImZXZqUkPRpP7ANFq%2FcBLGpA7NjDEZkn5Yy8Ykth4PQLFGemIN8L8%2FOjowE0Ota4IDoFjbVZzs8AUFwD5NIV5oyOuQFM6vUcJuMNgoXfnhUB8HK7fiDDBJd6MJe1COrNIumVn0LgT6KIZg5Fexdg9EYmP%2BDtMYgxIZ1NMzaoCh%2BZkOumS6XssMFb3pOUzaGSbJSqA7dLWzNro4LQss5eOZiGGaHZuIIQY%2FZxOpyUQ6nWmi6l3IsfvqZO27LBZYdEvdURHo2OpVFgnXAXGVZuerZn4lg2S%2BvCGbn99Ym1OysucJrVk2J3DrX7j9S3UJyydQDkUJ880A6pewrJjMdnv4lmz0wpuh590d9ttJtV1eJIKvY3cHeaBSJPjp45%2BTaKOXCbHxebOXSvFram%2Fv0pu9NKQF8ueT7vYVLQY4A%2Fz7AX6o9S%2FVQbYiKwN5Tdcvh5qpJP80UehwsaakXrS7V9rwtTFzAZ9uP%2F8WYYDF1oEGDhUDpX8XDOy3%2BTq2%2FCqjIM2hQtEOYA%2FIm%2BF78ob9cCVmpBg2tpwFmPdZLWpWC4l36FYtinYGC9Xiebk8q0UbaiHZGKxbtRBzaq4WFJ91oVFdSHYA7UAZ5GmFbEEWUwZeNzinlIcnE8ZuXdAPizOb0wXZGqMwxQzIOcVsSyvMYwsuu9nK6sBCemFSuH%2F3%2B9IbRbU1DbvH%2FpoX%2FwNj0ZqG7Z9p02%2F%2BDw%3D%3D) or download [this file](/tax_calculator_design.drawio)
 and run it over at [draw.io](https://app.diagrams.net/)
## Third Party Packages:

- [EFCore](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore) - Standard ORM
- [Moq](https://github.com/moq/moq4) - For mocking data in unit tests