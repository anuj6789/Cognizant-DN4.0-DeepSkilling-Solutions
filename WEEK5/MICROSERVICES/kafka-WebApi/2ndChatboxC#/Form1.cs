
using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kafkaChat
{
    public partial class Form1 : Form
    {
        private void StartKafkaConsumer()
        {
            cts = new CancellationTokenSource();
            CancellationToken token = cts.Token;

            var config = new ConsumerConfig
            {
                BootstrapServers = "localhost:9092",
                GroupId = "chat-group",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            consumerTask = Task.Run(() =>
            {
                using (var consumer = new ConsumerBuilder<Ignore, string>(config).Build())
                {
                    consumer.Subscribe("chat-topic");

                    try
                    {
                        while (!token.IsCancellationRequested)
                        {
                            var cr = consumer.Consume(token);
                            Invoke(new Action(() =>
                            {
                                listBox1.Items.Add($"Received: {cr.Message.Value}");
                            }));
                        }
                    }
                    catch (OperationCanceledException)
                    {
                        
                    }
                    finally
                    {
                        consumer.Close();
                    }
                }
            }, token);
        }

        private CancellationTokenSource cts;
        private Task consumerTask;
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            string message = richTextBox1.Text.Trim();

            if (string.IsNullOrEmpty(message))
            {
                MessageBox.Show("Message cannot be empty.");
                return;
            }

            var config = new ProducerConfig { BootstrapServers = "localhost:9092" };

            var producer = new ProducerBuilder<Null, string>(config).Build();

            try
            {
                await producer.ProduceAsync("chat-topic", new Message<Null, string> { Value = message });
                listBox1.Items.Add($"You: {message}");
                richTextBox1.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Send failed: {ex.Message}");
            }
            finally
            {
                producer.Dispose();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Task.Run(() => StartKafkaConsumer());
        }

    }
}
