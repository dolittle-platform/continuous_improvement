/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 * --------------------------------------------------------------------------------------------*/

using Machine.Specifications;

namespace Infrastructure.Services.Github.Webhooks.Handling.for_WebhookProcessor.when_processing
{

    [Subject(typeof(IWebhookProcessor), "Process")]
    public class and_the_processor_returns_a_task : given.a_webhook_processor
    {
        static Webhook webhook;
        static given.task_webhook_handler handler_instance;
        static Octokit.ActivityPayload payload;

        Establish context = () => 
        {
            payload = new Octokit.ActivityPayload();
            handler_instance = new given.task_webhook_handler();
            container.Setup(_ => _.Get(handler_instance.GetType())).Returns(handler_instance);
            webhook = BuildWebhook<given.task_webhook_handler>(payload);
        };

        Because of = async () => await processor.Process(webhook);

        It should_call_the_handler_method_with_the_payload = () => handler_instance.CalledWithPayload.ShouldEqual(payload);
    }    
}