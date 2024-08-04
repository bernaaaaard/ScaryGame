//// Formatting / reference guide for how this will behave in the game ////

// ### GENERAL NOTES ### //
- The way this is built currently, every time a story is triggered it restarts the story fresh. So, any INK features that depends on knowing what happened in a previous story that ended doesn't work currently :(

    Using a sequence is an example: {This will always play| this will never}. 
    -> Loop

    == Loop ==
    This stuff does work if it is contained within one playback of a story, though.
    For instance: <> 
        {once:
            - This will be played the first time, then loop 
            - second time -> Choices
        }
    -> Loop

    == Choices ==
    >:)

- We don't have functionality for choices, so hitting a choice ends the story.
    -> Formatting



// ### Formatting notes ###//
== Formatting == 
- Any segments of dialogue that should be queued individually have to be created in their own knot. (When put into the game, the knot has to be spelled correctly) 
- Anything done flow-wise (diverts, loops, etc) will happen as normal until it hits an end state.
- For notes, defining which knots are notes is done in the engine. Doing something to mark them in the INK file would be helpful, though. Either in naming, tags, or just having a seperate INK file for notes. Up to you.
    #TagExample
- To end a knot, use the END divert. Like this
-> END


// ### Example ###
== Example ==
For seperate strings of dialogue, it's best to seperate each into its own knot. If it gets too annoying, I can try to adjust the system to make it cleaner within INK if I think I'll have enough time to by the deadline. I kinda just speedran putting this together, lmao.
-> END

== Walmart1 ==
{shuffle:
    - "Welcome to Walmart."
    - "Hello."
    - "Welcome."
}
-> END

== Walmart2 ==
"No, we don't have any mason jars."
-> END

== Walmart3 ==
"Or Pomni figurines."
"Or the Rainbow Dash ones."
"Or any of the pokemon stuff"
-> END

== Walmart4 ==
"Don't ask."
-> END
