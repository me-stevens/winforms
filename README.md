# Windows Forms Site

This site uses:

* Prism syntax highlighter by Lea Verou
* Prefix-free by Lea Verou
* Gallery animations by [Codrops](http://tympanus.net/codrops/)
* Tooltip animations by [Codrops](http://tympanus.net/Development/TooltipStylesInspiration/index.html)

The examples were conceived by A. Oltra. The code and site are mine.




## Site code

I wanted to have a URL like `site/category/title`, for which I added `permalink: /:categories/:title` to my **_config.yml** file. However, that generated URLs with spaces when the categories had more than one word. At this moment, Jekyll has some problems with URL generation from [categories that have several words](https://github.com/jekyll/jekyll-help/issues/129).

My first approach was to save a short name for the category in the `tag` variable, but, as far as I know, there is no `/:tags/` style for [permalinks in Jekyll](http://jekyllrb.com/docs/permalinks/). So I did the opposite:

 * Store the long name in the tag, for example `tag: "Introduction to C&#35;"`
 * Store a short name in the category, for example `category: "intro"`
 * Setting `permalink: /:categories/:title`

The images and thumbnails are consequently saved in `/img/categoryname`.

--------------------------

**Update:** I'm using just the categories now. I write the long category name manually in the home page, while using a hash array for the post pages:

```yml
pairing:
  "intro":  "Introduction to C&#35;"
  "events": "Events and delegates"
... etc
```

**Important:** Posts have only one category.


### Variables in posts:

#### Global
* `layout:     ` post
* `category:   ` a short and URL friendly name for the category

#### Local
* `title:      ` the title of the post
* `shortitle:  ` the short title for the homepage gallery
* `excerpt:    ` the excerpt for the homepage gallery
* `thumb:      ` the name of the thumb image for the gallery
* `thumb-small:` the name of the thumb image for the posts navigation



### Thumb sizes

I defined a size for the home gallery images (thumbs), and another for the intrapost navigation tooltip (small thumbs), setting the variables `thumbs` and `thumbs-small` in **_config.yml**. Then I call them in the html like this:

```html
<img src="path/to/img" width="{{ site.thumbs }}" height="{{ site.thumbs }}">
```

The name of the image files is then `name-thumb` and `name-thumb-small`.


### Reverse post sorting

The posts are sorted in reverse chronological order (from older to newer), for which the keyword `reversed` is used in the posts loop:

```liquid
{% for post in site.posts reversed %}
```


### Top navigation

I used the `page.previous` and `page.next` variables, and added a class `disabled` in case there are no more pages.

```html
{% if page.previous %}class="icon" href="{{ page.previous.url }}"{% else %}class="disabled"{% endif %}
```

The class `disabled` sets `display: none` in the svg and span inside the `a` tag.


### Excerpt

I didn't like the default behaviour of [Jekyll excerpts](http://jekyllrb.com/docs/posts/#post-excerpts) for this project, so I set it in every post's Front Matter and it serves as the page description as well as the snippet description in the home page gallery.

```yaml
excerpt: "My custom excerpt."
```

### Solutions

The "Solutions" section uses the old trick of the checkbox/radio button and the `:checked` property to hide and show the contents.

```html 
<div class="solution">
	<input type="checkbox" id="show">
	<label for="show" class="icon btn yellow">See Solution</label>
	<div class="contents">
       ...
    </div>
</div>
```

```css
.solution .contents, 
.solution input {
	display: none;
}

.solution [type=checkbox]:checked ~ .contents {
	display: block;
}
```


## Disqus comments

Disqus provides [a page](https://help.disqus.com/customer/portal/articles/472138-jekyll-installation-instructions) where they explain the way to use it with Jekyll. They tell you to add a `comments: true` variable in the Front Matter of your post pages, and then add `{% if page.comments %}Paste universal code here{% endif %}` in the appropiate page template.

To keep things clean, I pasted the universal code in a file inside the `_includes` folder and then I use `{% if page.comments %}{% include disqus.html %}{% endif %}` in the **default** template.

However, that means writing `comments: true` manually in every post page. Since I will have mainly post pages and all of them will include comments, except for a very few exceptions, it seemed like a better idea to add `comments: true` to the Front Matter of the **post** template, and then add `comments: false` to the specific posts where I didn't want to display comments, changing also the `if` condition to `if page.comments == true`. This approach doesn't work, though; it prints the comments in every post.

So I removed the `comments: true` from the Front Matter of the post template, and I just check if the page is a post with the `page.date` variable. Also, I add a `nocomments: true` only to the posts that doesn't display comments. So I finally have this:

```liquid
{% if page.date and page.nocomments == null %}{% include disqus.html %}{% endif %}

```

and so, I can do less repetitive typing.



## Site design

Since this is all about Windows, I recovered that [good ol' desktop green](https://www.google.com/search?q=windows+95+desktop&tbm=isch) of the first Windows editions, just after they dropped the cheesy cloudy background, and just before the most mainstream grassy hills evah hit the fame and fortune pot (did you know there's a [documentary](https://www.youtube.com/watch?v=AVXY8OEZAEQ) where the photographer explains how he took that picture?).

I added some modern stuff here and there to make it look fresh. Let me know if it hurts your eyes.


**(Silly) Note:** There seem to be two different sharps, &#35; (`&#35;`) and &#x266F; (`&#x266F;`). The second one seems to be the one used in music notation, so I went with the first. There is also &#9839; (`&#9839;`)
