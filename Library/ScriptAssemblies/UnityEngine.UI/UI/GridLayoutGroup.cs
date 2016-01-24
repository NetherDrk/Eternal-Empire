// Decompiled with JetBrains decompiler
// Type: UnityEngine.UI.GridLayoutGroup
// Assembly: UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 938FCF70-5523-4069-92C9-13E1F770A2CC
// Assembly location: C:\Users\Gabriel\Desktop\Unity\Eternal Empire\Library\UnityAssemblies\UnityEngine.UI.dll

using UnityEngine;

namespace UnityEngine.UI
{
  /// <summary>
  /// 
  /// <para>
  /// Layout child layout elements in a grid.
  /// </para>
  /// 
  /// </summary>
  [AddComponentMenu("Layout/Grid Layout Group", 152)]
  public class GridLayoutGroup : LayoutGroup
  {
    [SerializeField]
    protected Vector2 m_CellSize = new Vector2(100f, 100f);
    [SerializeField]
    protected Vector2 m_Spacing = Vector2.zero;
    [SerializeField]
    protected int m_ConstraintCount = 2;
    [SerializeField]
    protected GridLayoutGroup.Corner m_StartCorner;
    [SerializeField]
    protected GridLayoutGroup.Axis m_StartAxis;
    [SerializeField]
    protected GridLayoutGroup.Constraint m_Constraint;

    /// <summary>
    /// 
    /// <para>
    /// Which corner should the first cell be placed in?
    /// </para>
    /// 
    /// </summary>
    public GridLayoutGroup.Corner startCorner
    {
      get
      {
        return this.m_StartCorner;
      }
      set
      {
        this.SetProperty<GridLayoutGroup.Corner>(ref this.m_StartCorner, value);
      }
    }

    /// <summary>
    /// 
    /// <para>
    /// Which axis should cells be placed along first?
    /// </para>
    /// 
    /// </summary>
    public GridLayoutGroup.Axis startAxis
    {
      get
      {
        return this.m_StartAxis;
      }
      set
      {
        this.SetProperty<GridLayoutGroup.Axis>(ref this.m_StartAxis, value);
      }
    }

    /// <summary>
    /// 
    /// <para>
    /// The size to use for each cell in the grid.
    /// </para>
    /// 
    /// </summary>
    public Vector2 cellSize
    {
      get
      {
        return this.m_CellSize;
      }
      set
      {
        this.SetProperty<Vector2>(ref this.m_CellSize, value);
      }
    }

    /// <summary>
    /// 
    /// <para>
    /// The spacing to use between layout elements in the grid.
    /// </para>
    /// 
    /// </summary>
    public Vector2 spacing
    {
      get
      {
        return this.m_Spacing;
      }
      set
      {
        this.SetProperty<Vector2>(ref this.m_Spacing, value);
      }
    }

    /// <summary>
    /// 
    /// <para>
    /// Which constraint to use for the GridLayoutGroup.
    /// </para>
    /// 
    /// </summary>
    public GridLayoutGroup.Constraint constraint
    {
      get
      {
        return this.m_Constraint;
      }
      set
      {
        this.SetProperty<GridLayoutGroup.Constraint>(ref this.m_Constraint, value);
      }
    }

    /// <summary>
    /// 
    /// <para>
    /// How many cells there should be along the constrained axis.
    /// </para>
    /// 
    /// </summary>
    public int constraintCount
    {
      get
      {
        return this.m_ConstraintCount;
      }
      set
      {
        this.SetProperty<int>(ref this.m_ConstraintCount, Mathf.Max(1, value));
      }
    }

    protected GridLayoutGroup()
    {
    }

    protected override void OnValidate()
    {
      base.OnValidate();
      this.constraintCount = this.constraintCount;
    }

    /// <summary>
    /// 
    /// <para>
    /// Called by the layout system.
    /// </para>
    /// 
    /// </summary>
    public override void CalculateLayoutInputHorizontal()
    {
      base.CalculateLayoutInputHorizontal();
      int num1;
      int num2;
      if (this.m_Constraint == GridLayoutGroup.Constraint.FixedColumnCount)
        num2 = num1 = this.m_ConstraintCount;
      else if (this.m_Constraint == GridLayoutGroup.Constraint.FixedRowCount)
      {
        num2 = num1 = Mathf.CeilToInt((float) ((double) this.rectChildren.Count / (double) this.m_ConstraintCount - 1.0 / 1000.0));
      }
      else
      {
        num2 = 1;
        num1 = Mathf.CeilToInt(Mathf.Sqrt((float) this.rectChildren.Count));
      }
      this.SetLayoutInputForAxis((float) this.padding.horizontal + (this.cellSize.x + this.spacing.x) * (float) num2 - this.spacing.x, (float) this.padding.horizontal + (this.cellSize.x + this.spacing.x) * (float) num1 - this.spacing.x, -1f, 0);
    }

    /// <summary>
    /// 
    /// <para>
    /// Called by the layout system.
    /// </para>
    /// 
    /// </summary>
    public override void CalculateLayoutInputVertical()
    {
      float num = (float) this.padding.vertical + (this.cellSize.y + this.spacing.y) * (this.m_Constraint != GridLayoutGroup.Constraint.FixedColumnCount ? (this.m_Constraint != GridLayoutGroup.Constraint.FixedRowCount ? (float) Mathf.CeilToInt((float) this.rectChildren.Count / (float) Mathf.Max(1, Mathf.FloorToInt((float) (((double) this.rectTransform.rect.size.x - (double) this.padding.horizontal + (double) this.spacing.x + 1.0 / 1000.0) / ((double) this.cellSize.x + (double) this.spacing.x))))) : (float) this.m_ConstraintCount) : (float) Mathf.CeilToInt((float) ((double) this.rectChildren.Count / (double) this.m_ConstraintCount - 1.0 / 1000.0))) - this.spacing.y;
      this.SetLayoutInputForAxis(num, num, -1f, 1);
    }

    /// <summary>
    /// 
    /// <para>
    /// Called by the layout system.
    /// </para>
    /// 
    /// </summary>
    public override void SetLayoutHorizontal()
    {
      this.SetCellsAlongAxis(0);
    }

    /// <summary>
    /// 
    /// <para>
    /// Called by the layout system.
    /// </para>
    /// 
    /// </summary>
    public override void SetLayoutVertical()
    {
      this.SetCellsAlongAxis(1);
    }

    private void SetCellsAlongAxis(int axis)
    {
      if (axis == 0)
      {
        for (int index = 0; index < this.rectChildren.Count; ++index)
        {
          RectTransform rectTransform = this.rectChildren[index];
          this.m_Tracker.Add((Object) this, rectTransform, DrivenTransformProperties.Anchors | DrivenTransformProperties.AnchoredPosition | DrivenTransformProperties.SizeDelta);
          rectTransform.anchorMin = Vector2.up;
          rectTransform.anchorMax = Vector2.up;
          rectTransform.sizeDelta = this.cellSize;
        }
      }
      else
      {
        float num1 = this.rectTransform.rect.size.x;
        float num2 = this.rectTransform.rect.size.y;
        int num3;
        int num4;
        if (this.m_Constraint == GridLayoutGroup.Constraint.FixedColumnCount)
        {
          num3 = this.m_ConstraintCount;
          num4 = Mathf.CeilToInt((float) ((double) this.rectChildren.Count / (double) num3 - 1.0 / 1000.0));
        }
        else if (this.m_Constraint == GridLayoutGroup.Constraint.FixedRowCount)
        {
          num4 = this.m_ConstraintCount;
          num3 = Mathf.CeilToInt((float) ((double) this.rectChildren.Count / (double) num4 - 1.0 / 1000.0));
        }
        else
        {
          num3 = (double) this.cellSize.x + (double) this.spacing.x > 0.0 ? Mathf.Max(1, Mathf.FloorToInt((float) (((double) num1 - (double) this.padding.horizontal + (double) this.spacing.x + 1.0 / 1000.0) / ((double) this.cellSize.x + (double) this.spacing.x)))) : int.MaxValue;
          num4 = (double) this.cellSize.y + (double) this.spacing.y > 0.0 ? Mathf.Max(1, Mathf.FloorToInt((float) (((double) num2 - (double) this.padding.vertical + (double) this.spacing.y + 1.0 / 1000.0) / ((double) this.cellSize.y + (double) this.spacing.y)))) : int.MaxValue;
        }
        int num5 = (int) this.startCorner % 2;
        int num6 = (int) this.startCorner / 2;
        int num7;
        int num8;
        int num9;
        if (this.startAxis == GridLayoutGroup.Axis.Horizontal)
        {
          num7 = num3;
          num8 = Mathf.Clamp(num3, 1, this.rectChildren.Count);
          num9 = Mathf.Clamp(num4, 1, Mathf.CeilToInt((float) this.rectChildren.Count / (float) num7));
        }
        else
        {
          num7 = num4;
          num9 = Mathf.Clamp(num4, 1, this.rectChildren.Count);
          num8 = Mathf.Clamp(num3, 1, Mathf.CeilToInt((float) this.rectChildren.Count / (float) num7));
        }
        Vector2 vector2_1 = new Vector2((float) ((double) num8 * (double) this.cellSize.x + (double) (num8 - 1) * (double) this.spacing.x), (float) ((double) num9 * (double) this.cellSize.y + (double) (num9 - 1) * (double) this.spacing.y));
        Vector2 vector2_2 = new Vector2(this.GetStartOffset(0, vector2_1.x), this.GetStartOffset(1, vector2_1.y));
        for (int index = 0; index < this.rectChildren.Count; ++index)
        {
          int num10;
          int num11;
          if (this.startAxis == GridLayoutGroup.Axis.Horizontal)
          {
            num10 = index % num7;
            num11 = index / num7;
          }
          else
          {
            num10 = index / num7;
            num11 = index % num7;
          }
          if (num5 == 1)
            num10 = num8 - 1 - num10;
          if (num6 == 1)
            num11 = num9 - 1 - num11;
          this.SetChildAlongAxis(this.rectChildren[index], 0, vector2_2.x + (this.cellSize[0] + this.spacing[0]) * (float) num10, this.cellSize[0]);
          this.SetChildAlongAxis(this.rectChildren[index], 1, vector2_2.y + (this.cellSize[1] + this.spacing[1]) * (float) num11, this.cellSize[1]);
        }
      }
    }

    /// <summary>
    /// 
    /// <para>
    /// One of the four corners in a rectangle.
    /// </para>
    /// 
    /// </summary>
    public enum Corner
    {
      UpperLeft,
      UpperRight,
      LowerLeft,
      LowerRight,
    }

    /// <summary>
    /// 
    /// <para>
    /// An axis that can be horizontal or vertical.
    /// </para>
    /// 
    /// </summary>
    public enum Axis
    {
      Horizontal,
      Vertical,
    }

    /// <summary>
    /// 
    /// <para>
    /// A constraint on either the number of columns or rows.
    /// </para>
    /// 
    /// </summary>
    public enum Constraint
    {
      Flexible,
      FixedColumnCount,
      FixedRowCount,
    }
  }
}
