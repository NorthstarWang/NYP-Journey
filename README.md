# NYP-Journey
The preview website has been deployed at http://nyp-journey.azurewebsites.net

## Index

- [About](#about)
- [Getting Started](#getting-started)
- [Build using](#build-using)
- [Features](#features)
- [Database Model](#database-model)
- [Copyright](#copyright)
- [Author](#author)

## About

Due to consistent increment of Polytechnic Students, more requirements will be needed by Campus Community. Many individuals are now not fulfilled by the limited knowledge on paper and are struggled in finding a platform to guide them to study further in their interested aspects as well as find someone that can help you. In order to increase the opportunities of interaction between all teachers and students, make it much convenient, a new Web-based application need to be developed. Therefore, We came up with an web-based platform to solve these inconveniences. NYP Journey eases the users within campus by establishing a communication platform for users to investigate their academic concerns and share their learning experience. This idea is derived from question and answers sites like stack overflow and Quora which users can ask questions in different aspects and professionals can solve their problems. Furthermore, we would like a system that can encourage the users to interact with the platform more actively just like Grab. We hope that the platform can combine the advantages of the pure question & answer site and well-known service site to build a unique platform and bring convenient service to the users.

> The web app has been deployed on azure: https://education-system-nyp.azurewebsites.net/

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

#### Prerequisites

To be able to run the application, **.Net Framework SDK** is required.(Recommended version: .Net framework SDK V4.7.2)

Before running this application, please seed the database with following command in Package Manager Console to ensure the running of application

```c#
Update-Database
```

## Build using

- C# - Language
- ASP.NET Webform - Framework
- .Net framework SDK V4.7.2 - Runtime Environment
- Bootstrap 4 Keen Theme & Material-kit Pro - UI Framework
- MySQL

## Features

NYP Journey summary functions and features are [user identification system](#user-identification-system), [user profile](#user-profile), [wallet](#wallet), [question forum](#question-forum), [management tools](#management-tools), [notification menu](#notification-menu), [shop](#shop), [ranking](#ranking), [invitation system](#invitation-system), [reporting pages](#reporting-pages) and [credit system](#credit-system).

- ##### User identification system

  User register and login the account by key in correct credentials with their corresponding Admin Number(For Student)/NRIC(For Teacher). User can find back their password by receiving system’s email.

  - Registration

    - OTP

      The email will be sent to validate user's email.

    - form wizard

      The form will be shown step-by-step to guide the users more friendly.

  - Login

    By using users' own identity numbers, they will be able to sign in to the system.

  - Forgot password

    System will send password to users emails if they forget their passwords.

- ##### User profile

  User can customize their own head icon and leave comment under other users’ profile. The profile contains users’ posted blogposts and brief data statistics about what have user done in NYP Journey. User can also add their favorite blogposts to favorite section.

  - Customization

    Modifications in users' own profile icon and information are available.

  - Comment

    Users can leave comment under other users’ profile page.

  - Blog

    User can share their learning experience in Blog system. User can tip the author with credit and can add the blogpost to favorite. Administrator can highlight the blogpost to make it more obvious on blog list page.

- ##### Wallet

  User can check their own transaction history about their credits and shop purchase history which generate as Invoice. User can also top up their credit balance using PayPal.

  - PayPal

    If users need credits, they can purchase through PayPal API using real-life currency.

  - Transaction history

    User can view their credit transaction histories in My Wallet. 

- ##### Question forum

  User posts question with a credit reward, after being approved by management system, other users can answer the question and one of them will be picked as the best solution and claim the credit reward.

  - Ask Question

    All users can ask question in the forum, the posting of the question will cost credit as a reward to the best solution made. All user can answer the question and the best solution for the question poster will claimed the reward. User can also leave reply under the answer.

  - Manager Review System

    Before the question publishes to the public users, it will be reviewed by administrator, if the question is approved, it can be seen by all users, else, it will be deleted.

- ##### Management tools

  In order to manage the massive data more effectively, NYP Journey has a system that can only be accessed by admin account. The system can let the admin check the statistics of the website by data visualization. It is also able to edit all users’ information, posts and check the credit transaction record.

  - User management

    Admin is authorized to delete or modify any users' information.

  - Question management

    Admin can delete any question in the forum.

  - Blog management

    Admin can highlight the blog if the blog has quality content, the blog that has been highlighted will be more obvious for the viewers in the blog list.

- ##### Notification menu

  Users check their own action record in NYP Journey and can redirect to the corresponding page.

  - Action notify

    Every action user does, including of creation of question in the forum, posting blog and redeeming any book from the shop.

- ##### Shop

  Users redeem the credit for learning resources and the purchase invoice will be saved inside Wallet>Invoice.

  - Book shop

    The books can be redeemed by credit from wallet system.

- ##### Ranking

  User can see the overall ranking about users, blogposts and question forum in NYP Journey.

- ##### Invitation system

  Users invite their friends who have not yet get into NYP Journey with a invitation code. Both the new user who key in the code and the invitation code owner will be rewarded extra credit.

  - Invitation code

    Every user has their own unique invitation code, once the code has been key in by other new user that has not yet applied invitation code. Both users will be awarded credit that can redeem books in bookshop.

- ##### Reporting pages

  User can feedback in the questionnaire page and can type in if any issue occur in contact page.

## Database Model
![Database Model](./database.jpg)
## Copyright

- [Ownership of copyright](#ownership-of-copyright)
- [Copyright license](#copyright-license)
- [Data mining](#data-mining)
- [Permissions](#permissions)
- [Enforcement of copyright](#enforcement-of-copyright)
- [Infringing material](#infringing-material)

#### Ownership of copyright

I own the copyright in:

1. this website; and
2. the material on this website (including, without limitation, the text, computer code, images, artworks on this website).

#### Copyright license

We grant to you a worldwide non-exclusive royalty-free revocable license to:

1. View this website and the material on this website on a computer via a web browser;
2. Copy and store this website and the material on this website in      your web browser cache memory; and
3. Print pages from this website for your own [personal and non-commercial] use.

We do not grant you any other rights in relation to this website or the material on this website. In other words, all other rights are reserved.

For the avoidance of doubt, you must not adapt, edit, change, transform, publish, republish, distribute, redistribute, broadcast, rebroadcast or show or play in public this website or the material on this website (in any form or media) without our prior written permission.

#### Data mining

The automated and/or systematic collection of data from this website is prohibited.

#### Permissions

You may request permission to use copyright materials on this website by writing to 1527638985@qq.com

#### Enforcement of copyright

We take the protection of its copyright very seriously. If We discover

that you have used our copyright materials in contravention of the license above, we may bring legal proceedings against you seeking monetary damages and an injunction to stop you using those materials. You could also be ordered to pay legal costs.

If you become aware of any use of our copyright materials that contravenes or may contravene the license above, please report this by email to 1527638985@qq.com

#### Infringing material

If you become aware of any material on the website that you believe infringes your or any other person's copyright, please report this by email to 1527638985@qq.com

## Author

- [Wang Yang](https://github.com/NorthstarWang)

