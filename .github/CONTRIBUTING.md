# Contributing to Call Invoice Management (CIM)

First off, thank you for considering contributing to CIM. It's people like you that make CIM such a great tool.

## Where do I go from here?

If you've noticed a bug or have a feature request, make sure to check our [issues](https://github.com/LucxLab/cim-core/issues) if there's something similar to what you have in mind. If there isn't, feel free to open a new issue.

## Fork & create a branch

If this is something you think you can fix, then fork CIM and create a branch with a descriptive name.

We use the Gitflow branching model, so you should create a feature branch based on the `develop` branch. See more about the Gitflow branching model [here](https://www.atlassian.com/git/tutorials/comparing-workflows/gitflow-workflow).

Let's see some examples of good branch names:

```bash
git checkout -b feature/325-add-japanese-localization
git checkout -b bugfix/432-fix-invalid-response-code
```

## Test your changes

It's important to ensure that your changes don't break anything and that the code adheres to the existing style. Pull request without tests will not be accepted.

We don't required a minimum code coverage, but we expect that you write tests for your code (unit tests, integration tests, etc). Feel free to ask for help or check the existing tests for examples.

## Create a pull request

At this point, you should switch back to your `develop` branch and make sure it's up to date with CIM's master branch (the upstream repository). And rebase your feature branch on top of it.

After that, go to the CIM repository and create a new pull request to propose your changes.
