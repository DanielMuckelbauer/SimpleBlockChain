using SimpleBlockChain.BlockChain;
using Spectre.Console;

AnsiConsole.Markup("Simple Block Chain");

var blockChain = new BlockChain();

blockChain.AddTransaction(1);
blockChain.AddTransaction(2);
blockChain.CreateBlock();

blockChain.AddTransaction(3);
blockChain.AddTransaction(4);
blockChain.CreateBlock();

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
    blockNode.AddNode($"Hash: {block.Hash}");
    blockNode.AddNode($"Previous Hash: {block.PreviousHash}");
    return blockNode;
}

void AddTransactionNode(TreeNode blockNode, Block block)
{
    var transactionNode = blockNode.AddNode("Transactions");
    foreach (var transaction in block.Transactions)
    {
        transactionNode.AddNode(transaction.Data.ToString());
    }
}