# Bloom_Filter

## TLDR

Got this puppy working, but we took a bit of a winding path, which I'll put into greater detail below

## Known Issues

* **Spelling** - Programming has destroyed my spelling, so I apologize in advance of any spelling mistakes you might find
* **Auto-optimization** - many implementations I found had various methods of generating some optimizations for false positives versus number of items to be stored and number of hashes (i.e., uniqueness of a find in the problem space).  I ommitted this, because I didn't fully appreciate the math, but I do understand that the otimal bit array size can be figured out since the problem space is a known quantity, I just though it was outside the requirements of this test
* **Space Allocation** - I didn't make this customizable, since the most basic solution is the max, otherwise it's defensive coding.  In this day and age, a bit array of int.max is trivial, but wanted to make note of it.

## TDD With Bloom Filter

This is actually a little difficult to TDD, given it's a specific implementation.  If you look at my commit messages, you'll notice I tried switching it to a behavior or use case driven implementation.   One of the great values of tdd stems from creating solutions from use cases rather than trying to engineer solutions from the fore front.  A bloom filter is an implementation, not really a use case, so I started by creating a simple filter and using optimizations to force the creation of the bloom filter itself.  When it came time to impelement the bloom filter, I had behavioral tests that I could fall back on to insure my implementation fit the *behavior* we needed over the implementation we *wanted*.  The Result let me refactor and play around with several things, all while knowing that my basic use cases were covered.

## Acceptance Testing Versus Unit Testing

I abstracted the "acceptance tests" from the "unit tests" in a way that might bear some explaining.  I'm not religious on this front at all, it's simply a distiction that's served me well in the past.  In order to get to the point where I needed to a test to implement the BloomFilter, I chose optimization and a time frame to force the code required.  Admittedly, it's not a good unit test because we're not actually testing function, we're testing optimization and the sort of "opinion" of whether or not I need this additional code.  Before the bloom filter, the 10000 item test took over a minute to run, so a simple timer was enough to force the optimization.  If you think of this as an acceptance test, its far easier to communicate the requirement to developers and stake holders.  Again, functionally, both worked the same, but the lense of unit tests are function, and acceptance tests are perceieved "real world application of the whole system" makes the requirement easier to communicate.  Again, at least for me in the past.

## The Random String Debacle

I stole some code to create random strings, which provides a lesson in the importance of tests, and the importance of always starting in a red state.  I missed one here that ended up biting me in the butt later.  If I had more rigourously tested the negative case, I would have discovered that my random string generator was generating the same string every time and giving me a false positive.  This WORKED OUT though, because when I reached the end and added the ACCEPTANCE test of false positives being within tolerance, I discovered it.  This should really reinforce how nothing should be assumed, and the tdd method includes in it a way of testing your tests.

## I Love Bloom Filters

This is really cool.  If nothing else, I learned a really neat piece of engineering that drastically reduces seek time in large data sets in a way I hadn't thought of.  Really cool stuff.