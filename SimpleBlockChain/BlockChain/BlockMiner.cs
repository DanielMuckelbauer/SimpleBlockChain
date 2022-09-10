using SimpleBlockChain.BlockChain.Interfaces;

namespace SimpleBlockChain.BlockChain;

internal class BlockMiner : IBlockMiner
{
    public void Mine(BlockChain blockChain)
        => blockChain.CreateBlock();
}