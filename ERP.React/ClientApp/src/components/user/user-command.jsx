import * as React from "react";

export const UserCommand = props => {
  const { dataItem } = props;
  const inEdit = dataItem[props.editField];
  const isNewItem = dataItem.ProductID === undefined;

  return inEdit ? (
    <td className="k-command-cell">
      <button
        className="k-button k-grid-save-command"
        onClick={() => (isNewItem ? props.add(dataItem) : props.update(dataItem))}
      >
        {isNewItem ? "Add" : "Update"}
      </button>
      <button
        className="k-button k-grid-cancel-command"
        onClick={() => (isNewItem ? props.discard(dataItem) : props.cancel(dataItem))}
      >
        {isNewItem ? "Discard" : "Cancel"}
      </button>
    </td>
  ) : (
    <td className="k-command-cell">
      <button className="btn btn-success mx-1 k-grid-edit-command"
        onClick={() => props.edit(dataItem)}>
        <i className="fas fa-edit"></i>
      </button>
      <button className="btn btn-danger mx-1 k-grid-remove-command"
              onClick={() =>
                window.confirm("Bạn đồng ý xóa: " + dataItem.userName) &&
                props.remove(dataItem)
            }>
        <i className="fas fa-trash-alt"></i>
      </button>
    </td>
  );
};
