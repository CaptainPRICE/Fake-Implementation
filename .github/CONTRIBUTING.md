# How to Contribute

Contributions take many forms from submitting issues, writing docs, to making
code changes - we welcome it all!

## Getting Started

If you don't have a GitHub account, you can [sign up](https://github.com/signup/free)
as it will help you to participate with the project.

If you are running GitHub Desktop, you can clone this repository locally from
GitHub using the "Clone in Desktop" button from the Fake-Implementation project page,
or run this command in your Git-enabled Shell/Bash:

`git clone https://github.com/CaptainPRICE/Fake-Implementation.git fake-implementation`

If you want to make contributions to the project,
[forking the project](https://help.github.com/articles/fork-a-repo) is the
easiest way to do this. You can then clone down your fork instead:

`git clone https://github.com/MY-USERNAME-HERE/Fake-Implementation.git fake-implementation`

## How can I get involved?

We have an [`up for grabs`](https://github.com/CaptainPRICE/Fake-Implementation/labels/up%20for%20grabs)
tag on our issue tracker to indicate tasks which contributors can pick up.

If you've found something you'd like to contribute to, leave a comment in the issue
so everyone is aware.

## Making Changes

When you're ready to make a change, create a branch off the `master` branch:

```
git checkout master
git pull origin master
git checkout -b SOME-BRANCH-NAME
```

We use `master` as the default branch for the repository, and it holds the most
recent contributions. By working in a branch away from `master` you can handle
potential conflicts that may occur in the future.

If you make focused commits (instead of one monolithic commit) and have descriptive
commit messages, this will help speed up the review process.

### Submitting Changes

You can publish your branch from GitHub for Windows, or run this command from
the Git Shell/Bash:

`git push origin MY-BRANCH-NAME`

Once your changes are ready to be reviewed, publish the branch to GitHub and
[open a pull request](https://help.github.com/articles/using-pull-requests)
against it.

A few suggestions when opening a pull request:

 - If you are addressing a particular issue, reference it like this:

>   Fixes #1234

 - Prefix the title with `[WIP]` to indicate this is a work-in-progress. It's
   always good to get feedback early, so don't be afraid to open the PR before
   it's "done".
 - Use [checklists](https://github.com/blog/1375-task-lists-in-gfm-issues-pulls-comments)
   to indicate the tasks which need to be done, so everyone knows how close you
   are to done.
 - Add comments to the PR about things that are unclear or you would like
   suggestions on.

Some things that will increase the chance that your pull request is accepted:

* Follow existing code conventions.
* Update the documentation, the surrounding one, examples elsewhere, guides,
  whatever is affected by your contribution.

# Additional Resources

* [General GitHub documentation](http://help.github.com/)