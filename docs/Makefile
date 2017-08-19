all: serve-site

install-deps:
	sudo pacman -S --noconfirm ruby
	gem install bundler

build-site:
	mkdir -p vendor/bundle
	bundle install --path vendor/bundle

serve-site: build-site
	bundle exec jekyll serve

