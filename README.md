TinyTwitter
===========

Very simple library to access twitter from C# using the REST API. If you 
are looking for a full-featured library, take a look at [Twitterizer](http://www.twitterizer.net/)
or [TweetSharp](https://github.com/danielcrenna/tweetsharp).

How to use TinyTwitter
----------------------

Just grab the latest version of [TinyTwitter.cs](https://github.com/jmhdez/TinyTwitter/blob/master/src/TinyTwitter/TinyTwitter.cs) and include it in 
your project. That's all. No binary dependecies are needed.

To use TinyTwitter you need to create and register an application
with Twitter to obtain a valid set of OAuth application tokens. More info
about this can be found in [Twitter's docs](https://dev.twitter.com/docs/auth/tokens-devtwittercom).

Using those tokens, you can begin to use TinyTwitter to post 
and/or read tweets from your account:

	var oauth = new OAuthInfo
	{
		AccessToken = "YOUR ACCESS TOKEN",
		AccessSecret = "YOUR ACCES SECRET",
		ConsumerKey = "YOUR CONSUMER KEY",
		ConsumerSecret = "YOUR CONSUMER SECRET"
	};
	
	var twitter = new TinyTwitter(oauth);
	
	// Update status, i.e, post a new tweet
	twitter.UpdateStatus("I'm tweeting from C#");
	
	// Get home timeline tweets
	var tweets = twitter.GetHomeTimeline();
	
	foreach (var tweet in tweets)
		Console.WriteLine("{0}: {1}", tweet.UserName, tweet.Text);

Copyright and license
---------------------

Copyright 2012 Juan M. Hernández.

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this work except in compliance with the License.
You may obtain a copy of the License in the LICENSE file, or at:

   http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.