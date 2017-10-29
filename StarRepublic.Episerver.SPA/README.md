_A backender's attempt at Episerver as a single page application_

# Episerver as a single page application

Last week, I attended the event Episerver Partner Close-Up. The day was filled with presentation separated in a sales track and a developer track. Looking at the schema, two presentations caught my interest:

* Exploring OPE with Angular and React
* CMS as a service - headless

### Exploring OPE with Angular and React
They presented the exact same stuff that John blogged about some time ago:
[https://world.episerver.com/blogs/john-philip-johansson/dates/2017/10/taking-control-of-client-side-rendering-in-ope-beta/](https://world.episerver.com/blogs/john-philip-johansson/dates/2017/10/taking-control-of-client-side-rendering-in-ope-beta/)

### CMS as a service - headless
Episerver has basically developed a web API to get content. It relies on Episerver Find to provide free text search functionality. Since almost everything is content in Episerver, it should provide you with relevant data.

## Architechture
With these two features in mind, I was eager to try to combine them. That would allow me to create a single page application.

It shouldn't be difficult at all to create a simpler version of Episervers web API. I created two endpoints in my web API:

* `GET /contenttree`
* `GET /content?contentId={contentReference}`

The first one returns the entire content tree, based on the root node. The other one returns a model containing properties explicitely declared on a page type. You need to provide a content reference in order to get something returned. It won't provide you with free text search, therefore Episerver Find is not required. It just uses the content loader to get the data.

Voilá, headless CMS recreated!

In order to create a SPA, I'm using React to render my views. I'm using React Router to dynamically create routes and pages, based on the result of `/contenttree`. There is no specific reason for choosing React, other than it being a popular framework. Vue seems cool as well.

In Episerver I have created two really simple page types - start page and content page. They both contain a string property. For these, I have created three React components - start page component, content page component and string component. The page components are kind of partial views/templates for my page types, and the string component provides me with common markup, i.e. the data-epi-property-* attributes.

As a end user, this all works fine. So, SPA achieved. But so far, Episerver still has some stuff to do.

## Drawbacks

Surely Episerver has made their CMS more framework friendly... but only half way. I have gotten OPE to work when defining my routes and pages statically, but not when I dynamically create them. When I change route in my SPA, I lose all OPE functionality. I need a way to tell Episerver to re-analyze the HTML in order to give me my blue borders (OPE) back.

Conclusion, OPE works if your HTML contains data-epi-property-* attributes in a very early stage of your JS framework lifecycle. When I fetch properties via a web API, and then render the properties in my view, it seems it's too late for Episerver to attach OPE functionality.

Dojo uses RequireJS to expose a set of functions that Episerver use to initialize OPE. I have tried to call functions that I hoped would solve my issue, but after some time, and no success, I think this is a dead end. I hope Episerver will give us something easier.

## Conclusion

Episerver has made it easier for you to use a modern JS framework to render views. If you don't plan on creating a SPA, you might do well just following John's blog post. If you do plan on creating a SPA, it will come at the cost of you losing a lot of OPE functionality.

## Contribute

You may use this repository as you want. You are welcome to contribute by forking it or creating pull requests.