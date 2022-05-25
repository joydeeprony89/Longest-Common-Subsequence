using System;

namespace Longest_Common_Subsequence
{
  class Program
  {
    static void Main(string[] args)
    {
      string text1 = "abcde";
      string text2 = "ace";
      Solution s = new Solution();
      s.LongestCommonSubsequence(text1, text2);
    }
  }


  public class Solution
  {
    public int LongestCommonSubsequence(string text1, string text2)
    {
      // We are doing Dp bottom UP
      int m = text1.Length;
      int n = text2.Length;
      // create the DP array with extra row and column
      int[][] dp = new int[m + 1][];
      int row = dp.Length;

      for (int i = row - 1; i >= 0; i--)
      {
        dp[i] = new int[n + 1];
        int column = dp[i].Length;
        for (int j = column - 1; j >= 0; j--)
        {
          // for the last row and column set 0
          // this will help us for bottom Up calculation
          if (i == row - 1 || j == column - 1)
          {
            dp[i][j] = 0;
            continue;
          }
          // we are comparing both string from the End
          // When char match in both the string 
          if (text1[i] == text2[j])
          {
            // When match, we calculate the common seq by adding one to diagonal matrix position
            dp[i][j] = 1 + dp[i + 1][j + 1];
          }
          else
          {
            // When no match, common seq is Max(right, down) position
            dp[i][j] = Math.Max(dp[i][j + 1], dp[i + 1][j]);
          }
        }
      }

      // Answer is at the starting index position
      return dp[0][0];
    }
  }
}
