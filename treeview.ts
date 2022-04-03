/* simple two depth treeview by erith.id */
export type TreeItem = {
  title: string;
  expanded?: boolean;
  nodes?: TreeItem[];
};

import { useUuid } from "@mantine/hooks";
import { Settings } from "tabler-icons-react";
import { useState } from "react";
import _ from "lodash";

export type TreeViewProps = {
  items: TreeItem[];
  isEditable?: boolean;
  onNodeClick?: (selectedIndex: number[], title: string, depth: number) => void;
  onNodeChange?: (items: TreeItem[]) => void;
};

export const convertTreeItem = (v: string) => {
  console.log(v);
  const data = JSON.parse(v);
  const treeItems: TreeItem[] = new Array<TreeItem>();
  let i = 0;
  for (const [key, value] of Object.entries(data)) {
    const idx = treeItems.push({
      title: key,
      nodes: new Array<TreeItem>(),
    } as TreeItem);
    const items = Object.values(data[i])[0] as string[];
    items.map((b) => {
      treeItems[i].nodes!.push({ title: b, nodes: new Array<TreeItem>() });
    });
    i++;
  }

  return treeItems;
};

export const convertToJson = (items: TreeItem[]) => {
  const rows: any = [];
  items.map((m) => {
    let obj = {} as any;
    obj[m.title] = m.nodes?.map((n) => n.title) ?? [];
    rows.push(obj);
  });
  return JSON.stringify(rows);
};

export const TreeView = ({
  items,
  isEditable,
  onNodeClick,
  onNodeChange,
}: TreeViewProps) => {
  const [nodeValues, setNodeValuesTemp] = useState(items);

  const setNodeValues = (nv: TreeItem[]) => {
    setNodeValuesTemp(nv);
    onNodeChange?.call(this, nv);
  };

  const editable = isEditable ?? false;
  const editItem = (oldTitle: string, nodeIndex: number[]) => {
    if (nodeIndex.length == 2) {
      const title = window.prompt("input new name", oldTitle) ?? "";
      let nv = _.cloneDeep(nodeValues);

      nv[nodeIndex[0]].nodes![nodeIndex[1]].title = title;

      console.log(nv);
      setNodeValues(nv);
    } else {
      const title = window.prompt("input new name", oldTitle) ?? "";
      let nv = _.cloneDeep(nodeValues);

      nv[nodeIndex[0]].title = title;

      setNodeValues(nv);
    }
  };

  const deleteItem = (nodeIndex: number[]) => {
    if (nodeIndex.length == 2) {
      let nv = _.cloneDeep(nodeValues);
      nv[nodeIndex[0]].nodes?.splice(nodeIndex[1], 1);
      console.log(nv);
      setNodeValues(nv);
    } else {
      let nv = _.cloneDeep(nodeValues);
      nv?.splice(nodeIndex[0], 1);
      console.log(nv);
      setNodeValues(nv);
    }
  };
  const addItem = (nodeIndex?: number[]) => {
    if (nodeIndex == null) {
      const title = window.prompt("input new name") ?? "";
      let nv = _.cloneDeep(nodeValues);
      nv.push({ title: title, expanded: true });
      setNodeValues(nv);

      // let nv = _.cloneDeep(nodeValues);

      // nv[nodeIndex[0]].nodes?.splice(nodeIndex[1], 0, {
      //   title: "test",
      //   expanded: false,
      // });
      // setNodeValues(nv);
    } else if (nodeIndex?.length == 1) {
      let nv = _.cloneDeep(nodeValues);
      const title = window.prompt("input new name") ?? "";
      if (nv[nodeIndex[0]].nodes != null) {
        nv[nodeIndex[0]].nodes?.push({ title: title, expanded: true });
      } else {
        nv[nodeIndex[0]].nodes = [] as TreeItem[];
        nv[nodeIndex[0]].nodes?.push({ title: title, expanded: true });
      }
      nv[nodeIndex[0]].expanded = true;
      setNodeValues(nv);
    }
  };

  const uuid = useUuid();
  const uuid2 = useUuid();
  return (
    <div style={{ width: 300 }}>
      {isEditable && (
        <div>
          <button
            style={{ fontSize: 9, marginLeft: 5 }}
            onClick={(ev) => {
              addItem();
            }}
          >
            ADD ROOT
          </button>
        </div>
      )}

      <ul style={{ listStyle: "none", fontWeight: "bold", textAlign: "left" }}>
        {nodeValues.map((m, i) => {
          return (
            <li
              key={i}
              style={{
                position: "relative",
              }}
            >
              <span
                style={{ cursor: "pointer", userSelect: "none" }}
                onClick={(ev) => {
                  let nv = _.cloneDeep(nodeValues);
                  nv[i].expanded = !(nv[i].expanded ?? true);
                  setNodeValues(nv);
                }}
              >
                {m.expanded ?? true ? "-" : "+"}
              </span>{" "}
              <span
                onClick={(ev) => {
                  onNodeClick?.call(this, [i], m.title, 1);
                }}
              >
                {m.title} &nbsp;
              </span>
              {editable && (
                <Settings
                  size={18}
                  style={{ cursor: "pointer" }}
                  onClick={(ev) => {
                    const isDp =
                      document.getElementById(`cmdbox_${uuid}_${i}`)!.style
                        .display == "block"
                        ? true
                        : false;
                    document.getElementById(
                      `cmdbox_${uuid}_${i}`
                    )!.style.display = isDp ? "none" : "block";
                  }}
                ></Settings>
              )}
              <div
                id={`cmdbox_${uuid}_${i}`}
                style={{
                  position: "absolute",
                  display: "none",
                  backgroundColor: "#ffffff",
                  zIndex: 5,
                  border: "1px solid #ccc",
                  padding: 5,
                }}
              >
                <button
                  style={{ fontSize: 9, marginLeft: 5 }}
                  onClick={(ev) => {
                    editItem(m.title, [i]);
                    document.getElementById(
                      `cmdbox_${uuid}_${i}`
                    )!.style.display = "none";
                  }}
                >
                  EDIT
                </button>
                <button
                  style={{ fontSize: 9, marginLeft: 5 }}
                  onClick={(ev) => {
                    if (window.confirm("Delete OK?")) {
                      deleteItem([i]);
                    }
                    document.getElementById(
                      `cmdbox_${uuid}_${i}`
                    )!.style.display = "none";
                  }}
                >
                  DEL
                </button>
                <button
                  style={{ fontSize: 9, marginLeft: 5 }}
                  onClick={(ev) => {
                    addItem([i]);
                    document.getElementById(
                      `cmdbox_${uuid}_${i}`
                    )!.style.display = "none";
                  }}
                >
                  ADD
                </button>
                <button
                  style={{ fontSize: 9, marginLeft: 5 }}
                  onClick={(ev) => {
                    document.getElementById(
                      `cmdbox_${uuid}_${i}`
                    )!.style.display = "none";
                  }}
                >
                  CLOSE
                </button>
              </div>
              <ul
                id={`list_${uuid}`}
                style={{ display: m.expanded ?? true ? "block" : "none" }}
              >
                {m.nodes?.map((cn, j) => {
                  return (
                    <li key={j} style={{ position: "relative" }}>
                      <span
                        onClick={(ev) => {
                          onNodeClick?.call(this, [i], cn.title, 2);
                        }}
                      >
                        {cn.title} &nbsp;
                      </span>{" "}
                      {editable && (
                        <Settings
                          size={18}
                          style={{ cursor: "pointer" }}
                          onClick={(ev) => {
                            const isDp =
                              document.getElementById(
                                `cmdbox_${uuid2}_${i}${j}`
                              )!.style.display == "block"
                                ? true
                                : false;
                            document.getElementById(
                              `cmdbox_${uuid2}_${i}${j}`
                            )!.style.display = isDp ? "none" : "block";
                          }}
                        ></Settings>
                      )}
                      <div
                        id={`cmdbox_${uuid2}_${i}${j}`}
                        style={{
                          position: "absolute",
                          display: "none",
                          zIndex: 5,
                          backgroundColor: "#fff",
                          padding: 5,
                          border: "1px solid #ccc",
                        }}
                      >
                        <button
                          style={{ fontSize: 9, marginLeft: 5 }}
                          onClick={(ev) => {
                            editItem(cn.title, [i, j]);
                            document.getElementById(
                              `cmdbox_${uuid2}_${i}${j}`
                            )!.style.display = "none";
                          }}
                        >
                          EDIT
                        </button>
                        <button
                          style={{ fontSize: 9, marginLeft: 5 }}
                          onClick={(ev) => {
                            if (window.confirm("Delete OK?")) {
                              deleteItem([i, j]);
                            }
                            document.getElementById(
                              `cmdbox_${uuid2}_${i}${j}`
                            )!.style.display = "none";
                          }}
                        >
                          DEL
                        </button>
                        <button
                          style={{ fontSize: 9, marginLeft: 5 }}
                          onClick={(ev) => {
                            document.getElementById(
                              `cmdbox_${uuid2}_${i}${j}`
                            )!.style.display = "none";
                          }}
                        >
                          CLOSE
                        </button>
                      </div>
                    </li>
                  );
                })}
              </ul>
            </li>
          );
        })}
      </ul>
    </div>
  );
};

// import { TreeView, TreeItem, convertTreeItem, convertToJson } from "./TreeView";

// const treeValue = `[{"VVV":["111","222"]}, {"VVV1":["111","222"]}, {"VVV1":[]}]`;

// const testValues = [
//   {
//     title: "0",
//     nodes: [
//       { title: "111", nodes: [] },
//       { title: "222", nodes: [] },
//     ],
//   },
//   {
//     title: "1",
//     nodes: [
//       { title: "111", nodes: [] },
//       { title: "222", nodes: [] },
//     ],
//   },
//   { title: "2", nodes: [] },
//   { title: "vvv", expanded: true },
// ] as TreeItem[];

// export const Option = () => {
//   return (
//     <div>
//       <TreeView
//         isEditable={true}
//         items={convertTreeItem(treeValue)}
//         onNodeChange={(nv) => {
//           console.log("changed" + JSON.stringify(nv));
//           console.log("serialize" + convertToJson(nv));
//         }}
//       ></TreeView>
//     </div>
//   );
// };
