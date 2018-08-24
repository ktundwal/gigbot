using Microsoft.Bot;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EIBot.CommandHandling;

namespace Microsoft.EIBot.Bot
{
    public class EIBot : IBot
    {
        private const string SampleUrl = "https://github.com/tompaana/intermediator-bot-sample";

        public async Task OnTurn(ITurnContext context)
        {
            Command showOptionsCommand = new Command(Commands.ShowOptions);

            HeroCard heroCard = new HeroCard()
            {
                Title = "Hello!",
                Subtitle = "I am Expert Intelligence Bot",
                Text = $"<p>I’m going to help you get connected to an expert who can help you. I currently support 2 capabilities – Internet Research and Powerpoint Improvements. </p>" +
                       $"<p>For internet research just let me know the topic, analysis or datapoints that you’re looking for and I’ll get you connected with a research expert who will clarify the research (if needed) " +
                       $"and send you the results (typically 5-10 web links and a summary). </p> " +
                       $"<p>For Powerpoint I can apply visual cleanup to make slides consistent, " +
                       $"and I can also provide some great design tips from a professional powerpoint designer. " +
                       $"You’ll receive an updated powerpoint file with all my changes (we can update 5-10 slides with a summary of the changes we made). </p>" +
                       $"<p>Type 'human' to be connected right away</p>" +
                       $"<p>If you are an 'Agent' Click/tap the button below or type \"{new Command(Commands.ShowOptions).ToString()}\" to see all possible commands",
                Buttons = new List<CardAction>()
                {
                    new CardAction()
                    {
                        Title = "Show options",
                        Value = showOptionsCommand.ToString(),
                        Type = ActionTypes.ImBack
                    }
                }
            };

            Activity replyActivity = context.Activity.CreateReply();
            replyActivity.Attachments = new List<Attachment>() { heroCard.ToAttachment() };
            await context.SendActivity(replyActivity);
        }
    }
}
