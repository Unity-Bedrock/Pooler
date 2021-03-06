# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

## [0.0.1] - 2020-12-27

### Added

- Initial implementation.

## [0.0.2] - 2020-12-27

### Changed

- License and changelog.

## [1.0.0] - 2020-12-27

### Added

- Tests for all classes.
- Fix for the `BaseGameObjectFactory` not parenting newly instantiated objects correctly.

### Changed

- Some file names to be consistent with the class names they contain.

## [1.1.0] - 2021-01-02

### Added

- Option to specify maximum number of objects in the BasePooler.

### Changed

- Disabled tests using NSubstitute.

### Removed

- NSubstitute dependency.

## [1.1.1] - 2021-01-02

### Changed

- Fixed being able to go over the maximum capacity when returning objects to the BasePooler.