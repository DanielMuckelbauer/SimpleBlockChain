using SimpleBlockChain.BlockChain.Interfaces;
using Spectre.Console;

namespace SimpleBlockChain.BlockChain;

internal class Printer : IPrinter
{
    public void Print(BlockChain blockChain)
    {
        CreateTree(blockChain);

        void CreateTree(BlockChain chain)
        {
            var tree = new Tree("Blockchain");
            foreach (var block in chain.Chain)
            {
                var blockNode = CreateBlockNode(tree, block);
                AddTransactionNode(blockNode, block);
            }

            AnsiConsole.Write(tree);
            Console.ReadLine();
        }

        TreeNode CreateBlockNode(Tree tree, Block block)
        {
            var blockNode = tree.AddNode("Block");
            blockNode.AddNode($"Previous Hash: {block.PreviousHash}");
            blockNode.AddNode($"Hash: {block.Hash}");
            return blockNode;
        }

        void AddTransactionNode(TreeNode blockNode, Block block)
        {
            var transactionNode = blockNode.AddNode("Transactions");
            foreach (var transaction in block.Transactions)
            {
                transactionNode.AddNode(transaction.Data);
            }
        }
    }
}