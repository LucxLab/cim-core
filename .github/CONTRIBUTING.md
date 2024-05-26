# Contributing to Call Invoice Management (CIM)

First off, thank you for considering contributing to CIM. It's people like you that make CIM such a great application.

## Where do I go from here?

If you've noticed a bug or have a feature request, make sure to check our [issues](https://github.com/LucxLab/cim-core/issues) if there's something similar to what you have in mind. If there isn't, feel free to open a new issue.

## Fork & create a branch

If this is something you think you can fix or improve, then fork CIM and create a feature branch, with a descriptive name containing the issue identifier, based on the `main` branch.

Let's see some examples of good branch names:

```bash
git checkout -b feature/325-add-japanese-localization
git checkout -b bugfix/432-fix-invalid-response-code
```

## Test your changes

It's important to ensure that your changes don't break anything and that the code adheres to the existing style. Pull request without tests will not be accepted.

We don't require a minimum code coverage, but we expect that you write tests for your code (unit tests, integration tests, etc). Feel free to ask for help or check the existing tests for examples.

## Create a pull request

At this point, make sure your branch it's up-to-date with CIM's main branch (the upstream repository), or rebase your feature branch on top of it.

After that, go to the CIM repository and create a new pull request to propose your changes. Make sure to reference the issue you're addressing in the pull request description and write a detailed description of the changes.
